using System;
using System.Runtime.CompilerServices;

namespace GeneticAlgorithms.Core.Extensions
{
    public static class BoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool value) => Convert.ToInt32(value);
    }
}
