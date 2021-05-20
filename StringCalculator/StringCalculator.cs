using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var delimiter = new string[] { "," };
            var options = numbers.Split('\n', 2);
            List<int> nums;

            if (options[0].StartsWith("//["))
            {
                if (options[0].Remove(0, 3).Contains("["))
                {
                    delimiter = options[0].Remove(0, 3).Split("][", StringSplitOptions.RemoveEmptyEntries);
                    delimiter[delimiter.Length-1] = delimiter[delimiter.Length - 1].Replace("]", "");
                }
                else
                    delimiter = options[0].Remove(0, 3).Split("]", StringSplitOptions.RemoveEmptyEntries);

                nums = EvaluateNumbers(options[1], delimiter);
                return SumUpNumbers(nums);
            }
            else if(options[0].StartsWith("//"))
            {
                delimiter = new string[] { $"{options[0][2]}" };
                nums = EvaluateNumbers(options[1], delimiter);
                return SumUpNumbers(nums);
            }

            nums = EvaluateNumbers(numbers, delimiter);
            return SumUpNumbers(nums);
        }

        private static List<int> EvaluateNumbers(string numbers, string[] delimiters)
        {
            var numberstring = numbers.Trim().Replace("\n", delimiters[0]);
            var stringarray = numberstring.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

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
