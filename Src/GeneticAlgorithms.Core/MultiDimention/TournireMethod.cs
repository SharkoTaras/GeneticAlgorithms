using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GeneticAlgorithms.Core.MultiDimention
{
    public class TournireMethod
    {
        #region Private Fields
        private Random random;
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TournireMethod(uint individualsCount)
        {
            random = new Random();
            IndividualsCount = individualsCount;
        }
        #endregion

        #region Properties
        public uint IndividualsCount { get; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MDBitString Select(Func<MDBitString, double> eval)
        {
            var list = new List<MDBitString>();
            var count = 0;
            for (var i = 0; i < IndividualsCount; i++)
            {
                var ind = random.Next(0, count);
                list.Add(null);
            }
            return list.OrderBy(s => eval(s)).First();
        }

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
