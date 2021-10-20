using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MarsRover;

namespace GeziciUnitTest
{
    [TestClass]
    public class GeziciUnitTest
    {
        [TestMethod]
        public void Test1()
        {
            Gezici gezici = new Gezici()
            {
                X = 1,
                Y = 2,
                Yon = Yonler.N
            };

            var Plato = new List<int>() { 5, 5 };
            var hareketler = "LMLMLMLMM";

            gezici.Hareket(Plato, hareketler);

            var output = $"{gezici.X} {gezici.Y} {gezici.Yon}";
            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, output);
        }
        [TestMethod]
        public void Test2()
        {
            Gezici gezici = new Gezici()
            {
                X = 3,
                Y = 3,
                Yon = Yonler.E
            };

            var Plato = new List<int>() { 5, 5 };
            var hareketler = "MMRMMRMRRM";

            gezici.Hareket(Plato, hareketler);

            var output = $"{gezici.X} {gezici.Y} {gezici.Yon}";
            var expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, output);
        }
    }
}
