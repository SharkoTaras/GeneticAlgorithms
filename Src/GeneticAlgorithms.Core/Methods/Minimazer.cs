using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;
using GeneticAlgorithms.Core.MultiDimention;
using GeneticAlgorithms.Core.Operators;

namespace GeneticAlgorithms.Core.Methods
{
    public class Minimazer<T> where T : MDBitString
    {
        #region Constructors
        public Minimazer(AlgorithmContext context, Population<T> firstPopulation, Evaluator evaluator, M m)
        {
            Context = context;
            FirstPopulation = firstPopulation;
            Evaluator = evaluator;
            M = m;
            BestIndivides = new List<T>();
            MOperator = new MutateOperator(Context.MutateProbability);
            COperator = new CrossOperator(Context.CrossProbability);
        }
        #endregion

        #region Properties
        public AlgorithmContext Context { get; }
        public Population<T> FirstPopulation { get; }
        public Evaluator Evaluator { get; }
        public M M { get; }
        public Func<double, double> F { get; }

        public IList<T> BestIndivides { get; }

        public MutateOperator MOperator { get; private set; }
        public CrossOperator COperator { get; private set; }
        #endregion

        public T Minimize()
        {
            var currentPopulation = FirstPopulation;
            var tMethod = new TournireMethod<T>(currentPopulation, Context.TournireMethodIndividesCount);

            for (var i = 0; i < Context.MaxIterations; i++)
            {
                BestIndivides.Add(Evaluator.Eval(currentPopulation).Item2);
                var i1 = tMethod.Select(Evaluator);
                var i2 = tMethod.Select(Evaluator);

                i1 = MOperator.Mutate(i1);
                i2 = MOperator.Mutate(i2);

                var crossed = COperator.Cross(i1, i2);

                i1 = (T)crossed.ElementAt(0);
                i2 = (T)crossed.ElementAt(1);
                currentPopulation = new Population<T> { i1, i2 };
                for (var j = 0; j < Context.IndividesCount - 2; j++)
                {
                    currentPopulation.Add(MOperator.Mutate(tMethod.Select(Evaluator)));
                }

                tMethod = new TournireMethod<T>(currentPopulation, Context.TournireMethodIndividesCount);
            }
            return BestIndivides.OrderBy(s => Evaluator.Eval(s).Item1).First();
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
