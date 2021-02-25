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
            BetsIndivides = new List<BitString>();
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

        public IList<BitString> BetsIndivides { get; }

        public MutateOperator MOperator { get; private set; }
        public CrossOperator COperator { get; private set; }
        #endregion

        public BitString Minimize()
        {
            var a = 0;


            var currentPopulation = FirstPopulation;
            var tMethod = new TournireMethod(currentPopulation, Context.TournireMethodIndividesCount);

            for (var i = 0; i < Context.MaxIterations; i++)
            {
                BetsIndivides.Add(Evaluator.Eval(currentPopulation, Eval).individe);
                var i1 = tMethod.Select(Eval);
                var i2 = tMethod.Select(Eval);

                i1 = MOperator.Mutate(i1);
                i2 = MOperator.Mutate(i2);
                i1 = COperator.Cross(i1, i2).ElementAt(0);
                i2 = COperator.Cross(i1, i2).ElementAt(1);

            }

            return default;
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
