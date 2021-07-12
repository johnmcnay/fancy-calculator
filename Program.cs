using System;
using System.Collections.Generic;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");

            /* double x = getDoubleInput("Enter a number.");
             double y = getDoubleInput("Enter a second number, and I will add it to the first.");

             double result = x + y;*/
            Console.WriteLine("Enter what you would like to see added.");
            string equation = Console.ReadLine();

            string[] parts = equation.Split("+");
            double x;
            double y;

            Double.TryParse(parts[0], out x);
            Double.TryParse(parts[1], out y);

            double result = x + y;

            Console.WriteLine($"Result: {result}");
        }
        public static double getDoubleInput(string prompt)
        {
            bool loop;
            string input;
            double result;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                loop = !Double.TryParse(input, out result);
                if (loop)
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (loop);

            return result;
        }
    }



}
