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
            SetupInputs(1);
        }

        protected override void SetOutputSignal()
        {
            Output.SignalValue = !inputs[0].SignalValue;
        }
    }
}
