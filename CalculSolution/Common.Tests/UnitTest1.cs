using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculString0Test()
        {
            //arrange


            //act
            var result = OperList.CalculString("1", "2", "3", "Сложение");

            //assert
            Assert.AreEqual("1 + 2 = 3", result);
        }

        [TestMethod]
        public void CalculString1Test()
        {
            //arrange


            //act
            var result = OperList.CalculString("1", "2", "-2", "Вычитание");

            //assert
            Assert.AreEqual("1 - 2 = -2", result);
        }

        [TestMethod]
        public void CalculString2Test()
        {
            //arrange


            //act
            var result = OperList.CalculString("1", "2", "2", "Умножение");

            //assert
            Assert.AreEqual("1 * 2 = 2", result);
        }

        [TestMethod]
        public void CalculString3Test()
        {
            //arrange


            //act
            var result = OperList.CalculString("1", "2", "0,5", "Деление");

            //assert
            Assert.AreEqual("1 / 2 = 0,5", result);
        }

        [TestMethod]
        public void HistoryStringTest()
        {
            //arrange
            var what = "1 + 2 = 3";
            var when = "02.08.2012 10:30:00";

            //act
            var result = OperList.HistoryString(when, what);

            //assert
            Assert.AreEqual("02.08.2012 10:30:00 | 1 + 2 = 3", result);
        }
    }
}
