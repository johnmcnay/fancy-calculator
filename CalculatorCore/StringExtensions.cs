using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public static class StringExtensions
    {
        public static bool isValidCalculatorInputFormat(this string str)
        {
            return (str.isContinuationInputFormat() || str.isExpressionInputFormat());
        }

        public static bool isContinuationInputFormat(this string str)
        {
            string[] parts = str.Split(" ");

            return parts.Length == 2 && parts[0].isOperator();
        }

        public static bool isExpressionInputFormat(this string str)
        {
            string[] parts = str.Split(" ");

            return parts.Length == 3 && parts[1].isOperator();
        }

        public static bool isOperator(this string op)
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
    }
}
