using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.MultiDimention;

namespace GeneticAlgorithms.Core.Methods
{
    public class M
    {
        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public M(uint dimentionCount, IList<double> @as, IList<double> bs)
        {
            DimentionCount = dimentionCount;
            As = @as;
            Bs = bs;
        }
        #endregion

        #region Properties
        public uint DimentionCount { get; }
        public IList<double> As { get; }
        public IList<double> Bs { get; }
        #endregion

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public IEnumerable<double> Invoke<TIndividual>(Population<TIndividual> population)
        //{
        //    if (typeof(TIndividual) == typeof(MDBitString))
        //    {
        //        var result = new List<double>();

        //        foreach (var mdBitString in population as Population<MDBitString>)
        //        {
        //            result.Add(Invoke<MDBitString>(mdBitString));
        //        }

        //        return result;
        //    }

        //    return default;
        //}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<double> Invoke<TIndividual>(TIndividual individual)
        {
            if (typeof(TIndividual) == typeof(MDBitString))
            {
                var result = new List<double>();

                for (var i = 0; i < DimentionCount; i++)
                {
                    var bs = (individual as MDBitString)[i];
                    var number = bs.ToNumber();
                    result.Add(As[i] + (number * (Bs[i] - As[i]) / ((1 << bs.Count) - 1)));
                }

                return result;
            }

            return default;
        }

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
