using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Generators
{
    public interface IGenerator<TIndividual>
    {
        Population<TIndividual> Generate(uint membersCount, uint memberLenght);
    }
}
