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
            
            while (true)
            {

                Console.WriteLine("Enter in the operation you would like to perform");

                string equation = Console.ReadLine();
                if (equation.ToLower() == "exit")
                {
                    break;
                }
                if (equation.ToLower() == "history")
                {
                    if (history.Count == 0)
                    {
                        Console.WriteLine("No operations have been performed.");
                        continue;
                    }

                    displayHistory();

                    continue;
                }
                string op = getOperation(equation);

                if (isValidEquationInput(equation))
                {
                    string[] parts = equation.Split(" ");

                    if (isContinuation(parts))
                    {
                        if (history.Count == 0)
                        {
                            Console.WriteLine("Perform at least one complete calcuation.");
                            continue;
                        }

                        string log = $"{result} {op} {parts[1]}";

                        result = performOperation(result, op, Double.Parse(parts[1]));
                        history.Add(log + " = " + result.ToString());

                        maxEntryLength = Math.Max(log.Length, maxEntryLength);
                    } else
                    {
                        result = performOperation(Double.Parse(parts[0]), op, Double.Parse(parts[2]));
                        string log = $"{parts[0]} {op} {parts[2]}";                            
                        history.Add($"{log} = {result}");
                        maxEntryLength = Math.Max(log.Length, maxEntryLength);
                    }

                    Console.WriteLine($"Result: {result}");
                } else
                {
                    Console.WriteLine("An operation must be written in the form '5 + 8' or '+ 8'. Please try again.");
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
