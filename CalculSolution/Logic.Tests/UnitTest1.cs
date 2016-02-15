using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region Plus

        [TestMethod]
        public void PlusSmall()
        {
            //arrange

            //act
            var result = Operator.Plus(1, 2);

            //assert
            Assert.AreNotEqual(false,result.Success);
            Assert.AreEqual(3m,result.Number);
        }

        [TestMethod]
        public void PlusBig()
        {
            //arrange

            //act
            var result = Operator.Plus(int.MaxValue, 2);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(2147483649m, result.Number);
        }

        #endregion

        #region Minus

        [TestMethod]
        public void MinusSmall()
        {
            //arrange

            //act
            var result = Operator.Minus(1, 2);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(-1m, result.Number);
        }

        [TestMethod]
        public void MinusBig()
        {
            //arrange

            //act
            var result = Operator.Minus(int.MinValue, 2);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(-2147483650m, result.Number);
        }

        #endregion

        #region Multi

        [TestMethod]
        public void MultiSmall()
        {
            //arrange

            //act
            var result = Operator.Multi(1, 2);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(2m, result.Number);
        }

        [TestMethod]
        public void MultiBig()
        {
            //arrange

            //act
            var result = Operator.Multi(int.MinValue, int.MaxValue);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(-4611686016279904256m, result.Number);
        }

        #endregion

        #region Div

        [TestMethod]
        public void DivSmall()
        {
            //arrange

            //act
            var result = Operator.Div(1, 2);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(0.5m, result.Number);
        }

        [TestMethod]
        public void DivBig()
        {
            //arrange

            //act
            var result = Operator.Div(int.MinValue, int.MaxValue);

            //assert
            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(-1.0000000004656612875245796924m, result.Number);
        }

        [TestMethod]
        public void DivZero()
        {
            //arrange

            //act
            var result = Operator.Div(5, 0);

            //assert
            Assert.AreNotEqual(true, result.Success);
            
        }
        #endregion

    }
}
