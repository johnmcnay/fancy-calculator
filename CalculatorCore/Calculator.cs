using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        public decimal storedValue = 0;

        public EvaluationResult Evaluate(string input)
        {
            EvaluationResult result = new EvaluationResult();
            string[] parts = input.Split(" ");
            decimal x;
            decimal y;
          
            if (isOperator(parts[0]) && parts.Length == 2)
            {
                if (decimal.TryParse(parts[1], out x) == false)
                {
                    return new EvaluationResult { ErrorMessage = $"\u001b[31mThe first number, '{parts[1]}', was not a valid number.\u001b[0m" };
                }

                result = performOperation(storedValue, parts[0], x);
            } 
            else if (isOperator(parts[1]) && parts.Length == 3)
            {
                if (decimal.TryParse(parts[0], out x) == false)
                {
                    return new EvaluationResult { ErrorMessage = $"\u001b[31mThe first number, '{parts[0]}', was not a valid number.\u001b[0m" };
                }
                if (decimal.TryParse(parts[2], out y) == false)
                {
                    return new EvaluationResult { ErrorMessage = $"\u001b[31mThe second number, '{parts[2]}', was not a valid number.\u001b[0m" };
                }

                result = performOperation(x, parts[1], y);
            }
            else
            {
                return new EvaluationResult { ErrorMessage = "The operation must be in the form '5 + 8' or '+ 8'. Please try again." };
            }

            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                storedValue = result.Result;
            }

            return result;
        }

        public EvaluationResult performOperation(decimal x, string op, decimal y)
        {
            switch (op)
            {
                case "+":
                    return new EvaluationResult { Result = x + y };
                case "-":
                    return new EvaluationResult { Result = x - y };
                case "/":
                    return new EvaluationResult { Result = x / y };
                case "*":
                    return new EvaluationResult { Result = x * y };
                default:
                    return new EvaluationResult { ErrorMessage = $"The operator '{op}' is not valid. Must use + - * /" };
            }
        }

        public bool isOperator(string op)
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
