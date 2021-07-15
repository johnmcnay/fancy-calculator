using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class CalculatorCommand
    {
        private readonly static List<string> commands = new List<string>()
        {
            "history",
            "history +",
            "history -",
            "history *",
            "history /",
            "exit"
        };

        public String Action { get; set; }

        public CalculatorCommand(CalculatorInput input)
        {
            if (isValidCommand(input))
            {
                this.Action = input.InputString;
            }
            else
            {
                this.Action = null;
            }

        }

        public static bool isValidCommand(CalculatorInput input)
        {
            return commands.Contains(input?.InputString);
        }
    }

}
