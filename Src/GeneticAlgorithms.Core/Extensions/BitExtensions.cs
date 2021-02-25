using System;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Extensions
{
    public static class BitExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this int value) => Convert.ToBoolean(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this string value)
        {
            var number = Convert.ToInt32(value);
            if (number == 1 || number == 0)
            {
                return number.ToBool();
            }

            throw new FormatException("Only 1 or 0 values possible");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bit ToBit(this bool value) => new Bit(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this Bit bit) => bit.Value.ToInt();
    }
}
