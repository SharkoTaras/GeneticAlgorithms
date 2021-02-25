using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Operators
{
    public class CrossOperator
    {
        #region Private Fields
        private Random random;
        #endregion

        #region Constructors
        public CrossOperator(double crossProbability, Random random = null)
        {
            this.random = random ?? new Random();
            CrossProbability = crossProbability;
        }
        #endregion

        #region Propertiess
        public double CrossProbability { get; }
        #endregion

        public IEnumerable<BitString> Cross(BitString parrent1, BitString parrent2)
        {
            var randomNumber = random.NextDouble();
            if (randomNumber < CrossProbability)
            {
                var count = parrent1.Count;
                var ind = random.Next(0, count);
                var p1Bits = parrent1.Skip(count - ind - 1).ToList();
                var p2Bits = parrent2.Skip(count - ind - 1).ToList();

                var c1 = new BitString(parrent1.Value);
                var c2 = new BitString(parrent2.Value);

                for (int i = count - ind - 1, j = count - ind - 1; i < count; i++)
                {
                    c1.RemoveAt(j);
                    c2.RemoveAt(j);
                }

                c1.AddRange(p2Bits);
                c2.AddRange(p1Bits);
                return new BitString[] { c1, c2 };
            }
            return new BitString[] { parrent1, parrent2 };
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
