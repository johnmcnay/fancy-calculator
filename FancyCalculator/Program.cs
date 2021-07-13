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
            */
            double result = 0;
            List<string> history = new List<string>();

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

                    Console.WriteLine("All of the operations thus far:");

                    foreach (string entry in history)
                    {
                        Console.WriteLine(entry);   
                    }
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

                        string log = $"{result} {op} {parts[1]} = ";

                        result = performOperation(result, op, Double.Parse(parts[1]));
                        history.Add(log + result.ToString());


                    } else
                    {
                        result = performOperation(Double.Parse(parts[0]), op, Double.Parse(parts[2]));

                        history.Add($"{parts[0]} {op} {parts[2]} = {result}");
                    }

                    Console.WriteLine($"Result: {result}");
                } else
                {
                    Console.WriteLine("An operation must be written in the form '5 + 8' or '+ 8'. Please try again.");
                }
            }

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
