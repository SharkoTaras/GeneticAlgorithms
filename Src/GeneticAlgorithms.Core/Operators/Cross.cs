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
        public CrossOperator(double crossProbability)
        {
            random = new Random();
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
                var ind = random.Next(0, parrent1.Count + 1);
                var p1Bits = parrent1.Skip(ind);
                var p2Bits = parrent2.Skip(ind);

                parrent1.RemoveRange(ind, parrent1.Count - ind);
                parrent2.RemoveRange(ind, parrent1.Count - ind);

                parrent1.AddRange(p2Bits);
                parrent2.AddRange(p1Bits);
            }
            return new BitString[] { parrent1, parrent2 };
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
