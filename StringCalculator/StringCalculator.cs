using System;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var numberstring = numbers.Replace('\n', ',');

            var stringarray = numberstring.Split(',', StringSplitOptions.RemoveEmptyEntries);
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
