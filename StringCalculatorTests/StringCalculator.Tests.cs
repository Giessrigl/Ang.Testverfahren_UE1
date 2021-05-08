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
        [DataRow("2")]
        [DataRow("3")]
        [DataRow("75")]
        public void Add_Up_One_Number_In_String_Returns_That_Number(string numberstring)
        {
            var number = int.Parse(numberstring);
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), number);
        }

        [DataTestMethod]
        [DataRow("1,2")]
        [DataRow("3,4")]
        [DataRow("5,6")]
        public void Add_Up_Two_Numbers_In_String_Returns_Sum_Of_Numbers(string numberstring)
        {
            var stringarray = numberstring.Split(',');
            var result = int.Parse(stringarray[0]) + int.Parse(stringarray[1]);
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }
    }
}
