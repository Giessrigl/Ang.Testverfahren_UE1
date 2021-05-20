using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var delimiter = ',';
            var options = numbers.Split('\n', 2);
            List<int> nums;

            if (options[0].StartsWith("//"))
            {
                delimiter = options[0][2];
                nums = EvaluateNumbers(options[1], delimiter);
                return SumUpNumbers(nums);
            }

            nums = EvaluateNumbers(numbers, delimiter);
            return SumUpNumbers(nums);
        }

        private static List<int> EvaluateNumbers(string numbers, char delimiter)
        {
            var numberstring = numbers.Trim().Replace('\n', delimiter);
            var stringarray = numberstring.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            var accepted = true;
            var negativeNumbers = "";
            var nums = new List<int>();

            for (int i = 0; i < stringarray.Length; i++)
            {
                if (int.TryParse(stringarray[i], out int result))
                {
                    if (result < 0)
                    {
                        accepted = false;
                        negativeNumbers = negativeNumbers + result + ',';
                    }
                    else if (result > 1000)
                        continue;

                    nums.Add(result);
                }
            }

            if (!accepted)
            {
                negativeNumbers = negativeNumbers.Substring(0, negativeNumbers.Length - 1);
                throw new Exception("negatives not allowed - " + negativeNumbers);
            }

            return nums;
        }

        private static int SumUpNumbers(List<int> numbers)
        {
            var sum = 0;
            numbers.ForEach(num => sum += num);
            return sum;
        }
    }
}
