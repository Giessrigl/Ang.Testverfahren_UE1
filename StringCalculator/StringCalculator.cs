using System;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "")
                return 0;
            else
            {
                int.TryParse(numbers, out int result);
                return result;
            }
        }
    }
}
