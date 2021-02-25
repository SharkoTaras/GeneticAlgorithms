using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticAlgorithms.Tests
{
    [TestClass]
    public class BitTests
    {
        [TestMethod]
        public void BitToIntTest()
        {
            var bit = new Bit(1);

            var value = bit.ToInt();

            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void BitConstructorTest()
        {
            var bit = new Bit("1");

            Assert.AreEqual(1, bit.ToInt());

            bit = new Bit(true);

            Assert.AreEqual(true, bit.Value);

            bit = new Bit('1');

            Assert.AreEqual(1, bit.ToInt());

            Assert.ThrowsException<System.FormatException>(() =>
            {
                bit = new Bit("11");
            });
        }
    }
}
