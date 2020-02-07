using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalAnd : LogicalBase
    {
        public Input firstInput;
        public Input secondInput;

        public LogicalAnd()
        {
            firstInput = new Input(this);
            secondInput = new Input(this);
        }

        public override Boolean OutputSignal
        {
            get
            {
                return firstInput.Signal & secondInput.Signal;
            }
        }
    }
}
