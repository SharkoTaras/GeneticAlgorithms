using System;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;

namespace GeneticAlgorithms.ConsoleUI
{
    internal class Program
    {
        public static Func<double, double> f = (x) => (x * Math.Sin(10 * Math.PI * x)) + 1;

        public static Func<double, double> M = (x) => 3 / (1);

        public static Func<BitString, double> eval = str => f(M(str.ToNumber()));

        public static uint N { get; private set; }
        public static uint Nt { get; private set; }
        public static double Pm { get; private set; }
        public static double Pc { get; private set; }
        public static uint Maxt { get; private set; }
        public static int Maxtnc { get; private set; }
        public static double H { get; private set; }

        private static void Main(string[] args)
        {
            Init();
            var algorithmContext = new AlgorithmContext(N, Nt, Pm, Pc, Maxt, H);

        }

        private static void Init()
        {
            N = 4;
            Nt = 2;
            Pm = 0.1;
            Pc = 0.8;
            Maxt = 10;
            Maxtnc = 10;
            H = 0.1;
        }
    }
}
