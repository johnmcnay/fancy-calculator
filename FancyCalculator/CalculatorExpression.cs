using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class CalculatorExpression
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string MathOperator { get; set; }
        public string Expression { get; set; }

        public CalculatorExpression(CalculatorInput input)
        {
            if (isValidExpression(input))
            {
                this.Expression = input.InputString;
            }
            else
            {
                this.Expression = null;
            }


        }

        public static bool isValidExpression(CalculatorInput input)
        {
            string[] pieces = input?.InputString?.Split(" ");

            if (pieces.Length == 2)
            {
                return CalculatorInput.isValidOperator(pieces[0]) && CalculatorInput.isValidOperand(pieces[1]);
            }
            else if (pieces.Length == 3)
            {
                return CalculatorInput.isValidOperand(pieces[0]) && CalculatorInput.isValidOperator(pieces[1]) && CalculatorInput.isValidOperand(pieces[2]);
            }
            else
            {
                return false;
            }
        }

        public void evaluate()
        {
            
        }
    }
}
