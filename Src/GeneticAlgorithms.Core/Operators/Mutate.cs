using System;
using GeneticAlgorithms.Core.Entities;

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

        public BitString Mutate(BitString str)
        {
            var randomNumber = random.NextDouble();
            if (randomNumber < MutateProbability)
            {
                var count = str.Count;
                var ind = random.Next(0, str.Count);
                str[count - ind - 1] = !str[count - ind - 1];
            }
            return str;
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
