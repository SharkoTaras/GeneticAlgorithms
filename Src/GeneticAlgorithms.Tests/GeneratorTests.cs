using GeneticAlgorithms.Core.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticAlgorithms.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void GenerateTest()
        {
            var generator = new PopulationGenerator();

            var pop = generator.Generate(1, 3);

            Assert.AreEqual(1, pop.Count);
            foreach (var str in pop)
            {
                Assert.AreEqual(3, str.Count);
            }
        }
    }
}
