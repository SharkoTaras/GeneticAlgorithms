using System;
using System.Linq;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Methods
{
    public class Evaluator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double value, BitString individe) Eval(Population population, Func<BitString, double> f) => population.Select(s => Eval(s, f)).OrderBy(elem => elem.value).First();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double value, BitString individe) Eval(BitString bits, Func<BitString, double> f) => (f(bits), bits);
    }
}
