using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalOr : LogicalBase
    {
        public LogicalOr(Int32 numberInputs = 2)
        {
            SetupInputs(numberInputs);
        }

        protected override void SetOutputSignal()
        {
            foreach (Input input in inputs)
            {
                if (input.SignalValue == true)
                {
                    Output.SignalValue = true;
                    return;
                }
            }

            Output.SignalValue = false;
        }
    }
}
