using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Core.MultiDimention;

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

        public IEnumerable<MDBitString> Cross(MDBitString parrent1, MDBitString parrent2)
        {
            var randomNumber = random.NextDouble();
            if (randomNumber < CrossProbability)
            {
                var count = parrent1.Bits.Count;
                var ind = random.Next(0, count);

                var p1Bits = parrent1.RBits.Skip(count - ind - 1).ToList();
                var p2Bits = parrent2.RBits.Skip(count - ind - 1).ToList();

                var c1 = new MDBitString();
                var c2 = new MDBitString();
                for (var i = 0; i < parrent1.Count; i++)
                {
                    c1.Add(parrent1[i]);
                    c2.Add(parrent2[i]);
                }

                for (int i = count - ind - 1, j = count - ind - 1; i < count; i++)
                {
                    c1.RBits.RemoveAt(j);
                    c2.RBits.RemoveAt(j);
                }

                c1.RBits.AddRange(p2Bits);
                c2.RBits.AddRange(p1Bits);

                c1.SyncInnerBits(useRBits: true);
                c2.SyncInnerBits(useRBits: true);
                return new MDBitString[] { c1, c2 };
            }
            return new MDBitString[] { parrent1, parrent2 };
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
