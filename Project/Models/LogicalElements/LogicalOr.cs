using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalOr : LogicalBase
    {
        public LogicalOr()
        {
            inputs.Add(new Input(new Action(UpdateState)));
            inputs.Add(new Input(new Action(UpdateState)));
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
