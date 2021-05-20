using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        [DataRow("//-\n-1\n-2", 3)]
        [DataRow("//1\n3\n1215", 10)]
        public void Add_Up_Numbers_With_New_Delimiters_Returns_Sum_Of_Numbers(string numberstring, int result)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }

        [DataTestMethod]
        [DataRow("-1", "-1")]
        [DataRow("-1,2", "-1")]
        [DataRow("//;\n-1;2;-3\n-4", "-1,-3,-4")]
        [DataRow("-1\n \n-2,-3,4", "-1,-2,-3")]
        [DataRow("2,1005,-1004", "-1004")]
        public void Add_Up_Negative_Numbers_Returns_An_Exception(string numberstring, string negatives)
        {
            try
            {
                StringCalculator.StringCalculator.Add(numberstring);
                Assert.Fail();
            }
            catch(Exception e)
            {
                Assert.AreEqual(e.Message, "negatives not allowed - " + negatives);
            }
        }

        [DataTestMethod]
        [DataRow("1001", 0)]
        [DataRow("2,1005", 2)]
        [DataRow("//n\n8n1005n1000", 1008)]
        [DataRow("1005,1000,999", 1999)]
        public void Add_Up_Numbers_Returns_Sum_Of_Numbers_Ignoring_Numbers_Over_1000(string numberstring, int result)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }

        [DataTestMethod]
        [DataRow("//[***]\n1***2***3", 6)]
        [DataRow("//[;]\n8;1004;2", 10)]
        [DataRow("//[12]\n9121004122", 11)]
        public void Add_Up_Numbers_With_Any_Length_Of_Delimiter_Returns_Sum_Of_Numbers(string numberstring, int result)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }

        [DataTestMethod]
        [DataRow("//[*][%]\n1*2%3", 6)]
        public void Add_Up_Numbers_With_Multiple_Delimiters_Returns_Sum_Of_Numbers(string numberstring, int result)
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(numberstring), result);
        }
    }
}
