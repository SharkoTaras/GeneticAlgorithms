using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;
using GeneticAlgorithms.Core.Operators;

namespace GeneticAlgorithms.Core.Methods
{
    public class Minimazer
    {
        #region Constructors
        public Minimazer(AlgorithmContext context, Population firstPopulation, Func<double, double> f, Func<BitString, double> m)
        {
            Context = context;
            FirstPopulation = firstPopulation;
            F = f;
            M = m;
            BestIndivides = new List<BitString>();
            MOperator = new MutateOperator(Context.MutateProbability);
            COperator = new CrossOperator(Context.CrossProbability);

        }
        #endregion

        #region Properties
        public AlgorithmContext Context { get; }
        public Population FirstPopulation { get; }

        public Func<double, double> F { get; }
        public Func<BitString, double> M { get; }
        public Func<BitString, double> Eval => (s) => F(M(s));

        public IList<BitString> BestIndivides { get; }

        public MutateOperator MOperator { get; private set; }
        public CrossOperator COperator { get; private set; }
        #endregion

        public BitString Minimize()
        {
            var currentPopulation = FirstPopulation;
            var tMethod = new TournireMethod(currentPopulation, Context.TournireMethodIndividesCount);

            for (var i = 0; i < Context.MaxIterations; i++)
            {
                BestIndivides.Add(Evaluator.Eval(currentPopulation, Eval).individe);
                var i1 = tMethod.Select(Eval);
                var i2 = tMethod.Select(Eval);

                i1 = MOperator.Mutate(i1);
                i2 = MOperator.Mutate(i2);

                var crossed = COperator.Cross(i1, i2);

                i1 = crossed.ElementAt(0);
                i2 = crossed.ElementAt(1);
                currentPopulation = new Population { i1, i2 };
                for (var j = 0; j < Context.IndividesCount - 2; j++)
                {
                    currentPopulation.Add(MOperator.Mutate(tMethod.Select(Eval)));
                }
            }

            return BestIndivides.OrderBy(s => Eval(s)).First();
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
