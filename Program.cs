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

            while (true)
            {

                Console.WriteLine("Enter in the operation you would like to perform");

                string equation = Console.ReadLine();
                if (equation.ToLower() == "exit")
                {
                    break;
                }
                string op = getOperation(equation);
                string[] parts = equation.Split(op);

                if (parts.Length != 2)
                {
                    Console.WriteLine("An operation must be written in the form '5 + 8'. Please try again.");
                }

                double x = 0;
                double y = 0;
                double result;
                bool firstValid = false;
                bool secondValid = false;

                if (op != null & parts.Length == 2)
                {
                    firstValid = Double.TryParse(parts[0], out x);
                    secondValid = Double.TryParse(parts[1], out y);
                }

                if (op != null && firstValid && secondValid)
                {

                    result = performOperation(x, op, y);
                    Console.WriteLine($"Result: {result}");
                }
                else if (parts.Length == 2)
                {
                    if (!firstValid)
                    {
                        Console.WriteLine($"The first value, '{parts[0].Trim()}', is not a number.");
                    }
                    if (!secondValid)
                    {
                        Console.WriteLine($"The second value, '{parts[1].Trim()}', is not a number.");
                    }
                    if (op == null)
                    {
                        Console.WriteLine("Invalid Operator: Must use + - / *");
                    }
                }
            }

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

        public static string getOperation(string equation)
        {
            foreach (char ch in "+-*/") {
                if (equation.Contains(ch))
                {
                    return ch.ToString();
                }
            }
            return null;
        }

        public static double performOperation(double x, string op, double y)
        {
            switch (op)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "/":
                    return x / y;
                case "*":
                    return x * y;
                default:
                    return 0;
            }
        }
    }



}
