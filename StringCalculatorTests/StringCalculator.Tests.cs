using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTests
{
    [TestClass]
    public class Tests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow("   ")]
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

        [DataTestMethod]
        [DataRow("1,2,3")]
        [DataRow("4,5,6,7")]
        [DataRow("5,6,7,8,9")]
        [DataRow("7,8,9,10,11,12")]
        public void Add_Up_More_Than_Two_Numbers_In_String_Returns_Sum_Of_Numbers(string numberstring)
        {
            var stringarray = numberstring.Split(',');
            var result = 0;
            for (int i = 0; i < stringarray.Length; i++)
            {
                result += int.Parse(stringarray[i]);
            }

            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }

        [DataTestMethod]
        [DataRow("1\n2,3", 6)]
        [DataRow("1\n2\n3, 4", 10)]
        [DataRow("1\n \n2, 3,\n 4", 10)]
        public void Add_Up_Numbers_With_New_Lines_Between_Them_In_String_Returns_Sum_Of_Numbers(string numberstring, int result)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }

        [DataTestMethod]
        [DataRow("//;\n1;2", 3)]
        [DataRow("1,2", 3)]
        [DataRow("///\n1/2", 3)]
        public void Add_Up_Numbers_With_New_Delimiters_Returns_Sum_Of_Numbers(string numberstring, int result)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }
    }
}
