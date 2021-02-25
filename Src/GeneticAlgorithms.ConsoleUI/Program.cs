using System;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Generators;

namespace GeneticAlgorithms.ConsoleUI
{
    internal class Program
    {
        public static Func<double, double> f = (x) => (x * Math.Sin(10 * Math.PI * x)) + 1;
        public static Func<double, double> M = (x) => 3 / (1);
        public static Func<BitString, double> eval = str => f(M(str.ToNumber()));

        private static void Main(string[] args)
        {
            var population = new PopulationGenerator().Generate(5, 6);
        }
    }
}
