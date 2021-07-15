using System;
using System.Collections.Generic;

namespace FancyCalculator
{
    class Program
    {

        public static double result = 0;
        public static int maxEntryLength = 0;
        public static List<string> history = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");

            /* double x = getDoubleInput("Enter a number.");
             double y = getDoubleInput("Enter a second number, and I will add it to the first.");
            */

            do
            {
                Console.WriteLine("Enter in the operation you would like to perform.");

                CalculatorInput input = new CalculatorInput(Console.ReadLine());

                input.Execute();

            } while (true);

        }

        private static void displayHistory(string op)
        {
            Console.WriteLine("All of the operations thus far:");

            foreach (string entry in history)
            {
                if (getOperation(entry) == op)
                {
                    Console.WriteLine(formatHistory(entry));
                }
            }
        }

        private static void displayHistory()
        {
            Console.WriteLine("All of the operations thus far:");

            foreach (string entry in history)
            {
                Console.WriteLine(formatHistory(entry));
            }
        }

        private static string formatHistory(string entry)
        {

            string[] parts = entry.Split(" = ");

            string left = parts[0].PadRight(maxEntryLength, ' ');

            return $"{left} = {parts[1].Trim()}";
        }

        public static bool isContinuation(string[] parts)
        {
            return isOperator(parts[0]);
        }

        public static bool isValidEquationInput(string equation)
        {
            string[] parts = equation.Split(" ");

            return (hasValidOperator(parts) && hasValidOperands(parts));

        }

        public static bool hasValidOperands(string[] parts)
        {
            return ( (isOperator(parts[0]) && Double.TryParse(parts[1], out var output)) || 
                (isOperator(parts[1]) && Double.TryParse(parts[0], out var num1) && Double.TryParse(parts[2], out var num2)));
        }

        public static bool hasValidOperator(string[] parts)
        {
            return (isOperator(parts[0]) || isOperator(parts[1]));
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

        public static bool isOperator(string op)
        {
            foreach (char ch in "+-*/")
            {
                if (ch.ToString() == op)
                {
                    return true;
                }
            }
            return false;
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
