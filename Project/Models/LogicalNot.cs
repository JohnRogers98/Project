using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalNot : LogicalBase
    {
        public Input input;

        public LogicalNot()
        {
            input = new Input(this);
        }

        public override Boolean OutputSignal
        {
            get
            {
                return !input.Signal;
            }
        }
    }
}
