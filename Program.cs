using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");



            string num1;
            double x;
            bool loop = false;

            do
            {
                Console.WriteLine("Enter a number.");
                num1 = Console.ReadLine();

                loop = !Double.TryParse(num1, out x);

                if (loop)
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (loop);


            string num2;
            double y;
            loop = false;

            do
            {

                Console.WriteLine("Enter a second number, and I will add it to the first.");
                num2 = Console.ReadLine();

                loop = !Double.TryParse(num2, out y);
                if (loop)
                {
                    Console.WriteLine("Invalid Input");
                }


            } while (loop);

            double result = double.Parse(num1) + double.Parse(num2);

            Console.WriteLine($"Result: {result}");
        }




    }
}
