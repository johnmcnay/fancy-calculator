using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");

            Console.WriteLine("Enter a number.");

            string num1 = Console.ReadLine();

            Console.WriteLine("Enter a second number, and I will add it to the first.");

            string num2 = Console.ReadLine();
            double result = double.Parse(num1) + double.Parse(num2);

            Console.WriteLine($"Result: {result}");
        }




    }
}
