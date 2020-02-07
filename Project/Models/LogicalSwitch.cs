using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalSwitch : LogicalBase
    {
        public Input input;

        public LogicalSwitch()
        {
            input = new Input(this);
        }

        public override Boolean OutputSignal
        {
            get
            {
                return input.Signal;
            }
        }
    }
}
