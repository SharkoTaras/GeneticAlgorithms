using GeneticAlgorithms.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticAlgorithms.Tests
{
    [TestClass]
    public class BitStringTests
    {
        [TestMethod]
        public void ToNumberTest()
        {
            var str = new BitString("101");

            Assert.AreEqual("101", str.ToString());

            Assert.AreEqual(5, str.ToNumber());

            str = new BitString("1000100");

            Assert.AreEqual("1000100", str.ToString());

            Assert.AreEqual(68, str.ToNumber());
        }
    }
}