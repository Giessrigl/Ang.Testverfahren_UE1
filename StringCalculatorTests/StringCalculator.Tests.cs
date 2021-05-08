using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTests
{
    [TestClass]
    public class Tests
    {
        [DataTestMethod]
        [DataRow("")]
        public void Add_Up_Empty_String_Returns_0(string numberstring)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), 0);
        }

        [DataTestMethod]
        [DataRow("1")]
        public void Add_Up_One_Number_In_String_Returns_That_Number(string numberstring)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), 1);
        }
    }
}
