using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class CalculatorInput
    {
        public string InputString { get; set; }
        public CalculatorExpression Expression {get; set;}
        public CalculatorCommand Command { get; set; }

        public CalculatorInput(string inputString)
        {
            this.InputString = inputString;
            this.Expression = new CalculatorExpression(this);
            this.Command = new CalculatorCommand(this);
        }
    
        public bool isValidInput()
        {
            return CalculatorExpression.isValidExpression(this) || CalculatorCommand.isValidCommand(this);
        }

        public static bool isValidOperand(string op)
        {
            return Double.TryParse(op, out var result);
        }

        public void Execute()
        {
            if (CalculatorExpression.isValidExpression(this))
            {
                this.Expression.evaluate();
            }
        }

        public static bool isValidOperator(string op)
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
