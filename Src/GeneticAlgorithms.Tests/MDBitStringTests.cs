using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;
using GeneticAlgorithms.Core.MultiDimention;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticAlgorithms.Tests
{
    [TestClass]
    public class MDBitStringTests
    {
        [TestMethod]
        public void GetSetTest()
        {
            var str = new MDBitString()
            {
                new BitString("1111"),
                new BitString("1011")
            };
            var bit = str.GetAt(2);
            Assert.AreEqual(0, bit.Value.ToInt());
            bit = !bit;
            str.SetAt(3, bit);
            Assert.AreEqual(true, str.GetAt(3).Value);
        }
    }
}
