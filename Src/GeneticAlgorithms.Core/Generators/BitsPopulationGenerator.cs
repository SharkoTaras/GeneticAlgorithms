using System;
using System.Runtime.CompilerServices;
using System.Text;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Generators
{
    public class BitsPopulationGenerator : IGenerator<BitString>
    {
        #region Private fields
        private Random random;
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitsPopulationGenerator() => random = new Random();
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Population<BitString> Generate(uint membersCount, uint memberLenght)
        {
            var population = new Population<BitString>();
            var sb = new StringBuilder();
            for (var i = 0; i < membersCount; i++)
            {
                for (var j = 0; j < memberLenght; j++)
                {
                    sb.Append(random.Next(2));
                }
                population.Add(new BitString(sb.ToString()));
                sb.Clear();
            }
            return population;
        }
    }
}
