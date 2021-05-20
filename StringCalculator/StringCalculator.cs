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
            var numberstring = numbers.Trim().Replace('\n', delimiter);

            var stringarray = numberstring.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;
            for (int i = 0; i < stringarray.Length; i++)
            {
                if (int.TryParse(stringarray[i], out int result))
                {
                    sum += result;
                }
            }

            return sum;
        }
    }
}
