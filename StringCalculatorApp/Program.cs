using System;

namespace StringCalculatorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Rules:");
            Console.WriteLine("numbers have to be delimited. The standard delimiter is: ,");
            Console.WriteLine("You can specify your delimiter as follows: //;\n");
            Console.WriteLine(" ; will become the new delimiter");
            Console.WriteLine("You can specify multiple delimiters like this: //[**][%]\n");
            Console.WriteLine("Then ** and % are the new delimiters.");
            Console.WriteLine("Negative numbers are not allowed!");
            Console.WriteLine("Neither allowed are numbers bigger than 1000!");

            Console.WriteLine(string.Empty);
            while(true)
            {
                Console.WriteLine("Type in the numbers you want to add:");
                var input = Console.ReadLine();
                input = input.Replace(@"\n", "\n");

                try
                {
                    Console.WriteLine(StringCalculator.StringCalculator.Add(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Do you want to add more numbers? [j / n]");
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == 'j')
                        break;
                    if (key.KeyChar == 'n')
                        Environment.Exit(1);
                }
            }
        }
    }
}
