using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        public decimal storedValue = 0m;
        public List<List<string>> history = new List<List<string>>();

        public EvaluationResult Evaluate(string input)
        {
            EvaluationResult result = new EvaluationResult();
            string[] parts = input.Split(" ");
            decimal x;
            decimal y;
          

            if (input.isValidCalculatorInputFormat())
            {
                if (input.isContinuationInputFormat())
                {
                    if (decimal.TryParse(parts[1], out x) == false)
                    {
                        return new EvaluationResult { ErrorMessage = $"The first number, '{parts[1]}', was not a valid number." };
                    }

                    result = performOperation(storedValue, parts[0], x);

                    if (String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        history.Add(new List<string>()
                        {
                            $"{storedValue} {input}",
                            result.Result.ToString()
                        });
                    }
                }
                else if (input.isExpressionInputFormat())
                {
                    if (decimal.TryParse(parts[0], out x) == false)
                    {
                        return new EvaluationResult { ErrorMessage = $"The first number, '{parts[0]}', was not a valid number." };
                    }
                    if (decimal.TryParse(parts[2], out y) == false)
                    {
                        return new EvaluationResult { ErrorMessage = $"The second number, '{parts[2]}', was not a valid number." };
                    }

                    result = performOperation(x, parts[1], y);

                    if (String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        history.Add(new List<string>()
                        {
                            input,
                            result.Result.ToString()
                        });
                    }
                }     
            }
            else
            {
                if (input.hasInvalidOperator())
                {
                    return new EvaluationResult { ErrorMessage = $"The operator '{(parts.Length == 2 ? parts[0] : parts[1])}' is not valid. Must use + - * /" };
                }

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

        public List<List<string>> getHistory()
        {
            return this.history;
        }
    }


}
