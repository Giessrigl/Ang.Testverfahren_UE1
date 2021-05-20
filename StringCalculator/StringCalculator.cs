using System;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var delimiter = ',';

            var options = numbers.Split('\n', 2);
            if (options[0].StartsWith("//"))
            {
                delimiter = options[0][2];
                return Addnumbers(options[1], delimiter);
            }

            return Addnumbers(numbers, delimiter);
        }

        private static int Addnumbers(string numbers, char delimiter)
        {
            var accepted = true;
            var negativeNumbers = "";

            var numberstring = numbers.Trim().Replace('\n', delimiter);
            var stringarray = numberstring.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;
            for (int i = 0; i < stringarray.Length; i++)
            {
                if (int.TryParse(stringarray[i], out int result))
                {
                    if (result < 0)
                    {
                        accepted = false;
                        negativeNumbers = negativeNumbers + result + ',';
                    }
                        
                    sum += result;
                }
            }

            if (!accepted)
            {
                negativeNumbers = negativeNumbers.Substring(0, negativeNumbers.Length - 1);
                throw new Exception("negatives not allowed - " + negativeNumbers);
            }
               
            return sum;
        }
    }
}
