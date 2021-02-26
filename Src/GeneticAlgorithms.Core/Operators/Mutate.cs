using System;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.MultiDimention;

namespace GeneticAlgorithms.Core.Operators
{
    public class MutateOperator
    {
        #region Private Fields
        private Random random;
        #endregion
        #region Constructors
        public MutateOperator(double mutateProbability)
        {
            random = new Random();
            MutateProbability = mutateProbability;
        }
        #endregion

        #region Propertiess
        public double MutateProbability { get; }
        #endregion

        public T Mutate<T>(T s)
            where T : class
        {
            if (typeof(T) == typeof(BitString))
            {
                var str = s as BitString;
                var randomNumber = random.NextDouble();
                if (randomNumber < MutateProbability)
                {
                    var count = str.Count;
                    var ind = random.Next(0, str.Count);
                    str[count - ind - 1] = !str[count - ind - 1];
                }

                return str as T;
            }

            if (typeof(T) == typeof(MDBitString))
            {
                var str = s as MDBitString;
                var randomNumber = random.NextDouble();
                if (randomNumber < MutateProbability)
                {
                    var count = str.Count;
                    var ind = (uint)random.Next(0, count);
                    str.SetAt(ind, !str.GetAt(ind));
                }

                return str as T;
            }
            return default;
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
