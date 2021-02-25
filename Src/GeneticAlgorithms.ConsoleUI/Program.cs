using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;
using GeneticAlgorithms.Core.Generators;
using GeneticAlgorithms.Core.Methods;

namespace GeneticAlgorithms.ConsoleUI
{
    internal class Program
    {
        //public static Func<double, double> f = (x) => x * x - 1;
        public static Func<double, double> f = (x) => (x * Math.Sin(10 * Math.PI * x)) + 1;

        public static Func<BitString, double> M = (x) => ((double)3 / ((1 << Bits) - 1) * x.ToNumber()) - 1;
        //public static Func<BitString, double> M = (x) => ((double)3 / ((1 << Bits) - 1) * x.ToNumber()) - 1;

        public static Func<BitString, double> eval = str => f(M(str));


        public static int a = -1;
        public static int b = 2;
        public static int Bits;
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
            Console.Write("Attempts: ");
            var attempts = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Print every attempt? (y/n): ");
            var input = Console.ReadLine();
            var print = input.Equals("Y", StringComparison.InvariantCultureIgnoreCase);
            var tries = new List<BitString>();
            var algorithmContext = new AlgorithmContext(N, Nt, Pm, Pc, Maxt, H);
            for (var i = 0; i < attempts; i++)
            {
                if (print)
                {
                    Console.WriteLine(new string('-', 20));
                }
                var p0 = new PopulationGenerator().Generate(N, (uint)Bits);

                var minimazer = new Minimazer(algorithmContext, p0, f, M);
                var bitstr = minimazer.Minimize();
                tries.Add(bitstr);
                if (print)
                {
                    Console.WriteLine($"Bit string: {bitstr}");
                    Console.WriteLine($"Real number: {M(bitstr)}");
                    Console.WriteLine($"f in string: {eval(bitstr)}");
                    Console.WriteLine(new string('-', 20));
                }
            }
            Console.WriteLine("Best result:");
            var str = tries.OrderBy(s => eval(s)).First();
            Console.WriteLine($"Bit string: {str}");
            Console.WriteLine($"Real number: {M(str)}");
            Console.WriteLine($"f in string: {eval(str)}");
        }

        private static void Init()
        {
            N = 100;
            Nt = 20;
            Pm = 0.1;
            Pc = 0.8;
            Maxt = 100;
            Maxtnc = 10;
            H = 0.001;
            Bits = (int)(Math.Log2((b - a) / H) + 1);
        }
    }
}
