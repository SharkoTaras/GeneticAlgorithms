using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Methods
{
    public class Evaluator
    {
        #region Constructor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Evaluator(M m, MethodInfo f)
        {
            M = m;
            F = f;
        }

        #endregion

        #region Properties
        public M M { get; }

        public MethodInfo F { get; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<double, TIndividual> Eval<TIndividual>(Population<TIndividual> population)
        {
            var result = new List<Tuple<double, TIndividual>>();

            foreach (var mdbstr in population)
            {
                result.Add(Eval(mdbstr));
            }

            return result.OrderBy(t => t.Item1).First();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<double, TIndividual> Eval<TIndividual>(TIndividual individual)
        {
            var arr = M.Invoke(individual).Cast<object>().ToArray();
            return new Tuple<double, TIndividual>((double)F.Invoke(null, arr), individual);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double value, BitString individe) Eval(Population<BitString> population, Func<BitString, double> f) => population.Select(s => Eval(s, f)).OrderBy(elem => elem.value).First();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double value, BitString individe) Eval(BitString bits, Func<BitString, double> f) => (f(bits), bits);
    }
}
