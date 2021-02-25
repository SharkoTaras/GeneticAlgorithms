using System;
using System.Linq;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Methods
{
    public class Evaluator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double value, BitString individe) Eval(Population population, Func<double, double> f) => population.Select(s => Eval(s, f)).OrderBy(elem => elem.value).First();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double value, BitString individe) Eval(BitString bits, Func<double, double> f) => (f(bits.ToNumber()), bits);
    }
}
