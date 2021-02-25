using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Extensions;

namespace GeneticAlgorithms.Core.Entities
{
    public class BitString : List<Bit>
    {
        #region Constructor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitString()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitString(string values) : base(values.Length) => ProcessString(values);
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ToNumber()
        {
            int result = default;

            for (int i = Count - 1, j = 0; i >= 0; i--, j++)
            {
                result += this[j].ToInt() << i;
            }

            return result;
        }

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => string.Join("", this);
        #endregion

        #region Helper methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessString(string values)
        {
            foreach (var bit in values)
            {
                Add(new Bit(bit));
            }
        }
        #endregion
    }
}
