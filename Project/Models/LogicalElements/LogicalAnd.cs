using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalAnd : LogicalBase
    {
        public LogicalAnd()
        {
            inputs.Add(new Input(new Action(UpdateState)));
            inputs.Add(new Input(new Action(UpdateState)));
        }

        protected override void SetOutputSignal()
        {
            foreach (Input input in inputs)
            {
                if (input.SignalValue == false)
                {
                    Output.SignalValue = false;
                    return;
                }   
            }

            Output.SignalValue = true;
        }
    }
}
