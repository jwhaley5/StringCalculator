using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Core;
using System;

namespace StringCalculatorTest
{
    [TestClass]
    public class CalculatorAdd
    {
        [TestMethod]
        public void EmptyString()
        {
            Calculator calc = new Calculator();
            int empty = calc.Add("");
            Assert.AreEqual(0, empty);
        }

        [TestMethod]
        public void OneNumber()
        {
            Calculator calc = new Calculator();
            int one = calc.Add("1");
            Assert.AreEqual(1, one);
        }

        [TestMethod]
        public void TwoNumbers()
        {
            Calculator calc = new Calculator();
            int three = calc.Add("1,2");
            Assert.AreEqual(3, three);
        }

        [TestMethod]
        public void MultipleNumbers()
        {
            Calculator calc = new Calculator();
            int number = calc.Add("1,2,4,5,6");
            Assert.AreEqual(18, number);
        }
        [TestMethod]
        public void MultipleNumbersAndNewLine()
        {
            Calculator calc = new Calculator();
            int number = calc.Add("1\n2,3");
            Assert.AreEqual(6, number);
        }

        [TestMethod]
        public void Delimiter()
        {
            Calculator calc = new Calculator();
            int number = calc.Add("//;\n1;2");
            Assert.AreEqual(3, number);
        }

        [TestMethod]
        public void MultipleDelimiters()
        {
            Calculator calc = new Calculator();
            int number = calc.Add("//up;\n1;2u8p9");
            Assert.AreEqual(20, number);
        }

        [TestMethod]
        public void Negative()
        {
            Calculator calc = new Calculator();
            try
            {
                int number = calc.Add("-1, 2");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negatives not allowed: -1");
            }
        }
        [TestMethod]
        public void MultipleNegatives()
        {
            Calculator calc = new Calculator();
            try
            {
                int number = calc.Add("2,-4,3,-5");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negatives not allowed: -4,-5");
            }
        }

        [TestMethod]
        public void Over1000()
        {
            Calculator calc = new Calculator();
            int number = calc.Add("1001,2");
            Assert.AreEqual(2, number);
        }


    }
}
