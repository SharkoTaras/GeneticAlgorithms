using System;
using System.Linq;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeneticAlgorithms.Tests
{
    [TestClass]
    public class CrossOperatorTests
    {
        [TestMethod]
        public void CrossTest()
        {
            var mock = new Mock<Random>();
            mock.Setup(x => x.NextDouble()).Returns(0.5);
            mock.Setup(x => x.Next(0, 5)).Returns(3);

            var s1 = new BitString("11011");
            var s2 = new BitString("01111");

            var cross = new CrossOperator(1, mock.Object);

            var crossed = cross.Cross(s1, s2);

            var ns1 = crossed.ElementAt(0);
            var ns2 = crossed.ElementAt(1);

            Assert.AreEqual("11111", ns1.ToString());
            Assert.AreEqual("01011", ns2.ToString());

            mock = new Mock<Random>();
            mock.Setup(x => x.NextDouble()).Returns(0.5);
            mock.Setup(x => x.Next(0, 5)).Returns(2);

            s1 = new BitString("11011");
            s2 = new BitString("01101");

            cross = new CrossOperator(1, mock.Object);

            crossed = cross.Cross(s1, s2);

            ns1 = crossed.ElementAt(0);
            ns2 = crossed.ElementAt(1);

            Assert.AreEqual("11101", ns1.ToString());
            Assert.AreEqual("01011", ns2.ToString());
        }
    }
}
