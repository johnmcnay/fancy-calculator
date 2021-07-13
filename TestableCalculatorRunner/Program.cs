using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            do
            {
                Console.WriteLine("Enter in an operation to perform:");

                string expression = Console.ReadLine();
                if (expression == "exit")
                {
                    break;
                }
                var result = calculator.Evaluate(expression);

                if (string.IsNullOrEmpty(result.ErrorMessage))
                {
                    Console.WriteLine(result.Result);
                }
                else
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            } while (true);
                       
        }
    }
}
