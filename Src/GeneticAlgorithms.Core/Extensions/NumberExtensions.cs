using System;
using System.Runtime.CompilerServices;

namespace GeneticAlgorithms.Core.Extensions
{
    public static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToPow(this double value, double power) => Math.Pow(value, power);
    }
}
