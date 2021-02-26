using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.MultiDimention;

namespace GeneticAlgorithms.Core.Generators
{
    public class MDBitsPopulationGenerator : IGenerator<MDBitString>
    {
        #region Private Firelds
        private IGenerator<BitString> BitStringGenerator;
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MDBitsPopulationGenerator(uint dimentionsCount)
        {
            BitStringGenerator = new BitsPopulationGenerator();
            DimentionsCount = dimentionsCount;
        }
        #endregion

        #region Properties
        public uint DimentionsCount { get; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Population<MDBitString> Generate(uint membersCount, uint memberLenght)
        {
            var a = 0;
            var population = new Population<MDBitString>();

            for (var i = 0; i < membersCount; i++)
            {
                var pop = BitStringGenerator.Generate(DimentionsCount, memberLenght);
                var mdStr = new MDBitString();
                foreach (var individual in pop)
                {
                    mdStr.Add(individual);
                }
                population.Add(mdStr);
            }

            return population;
        }

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
