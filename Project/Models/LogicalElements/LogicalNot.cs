using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalNot : LogicalBase
    {
        public LogicalNot()
        {
            inputs.Add(new Input(new Action(UpdateState)));
        }

        protected override void SetOutputSignal()
        {
            Output.SignalValue = !inputs[0].SignalValue;
        }
    }
}
