using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalAnd : LogicalBase
    {
        private Input firstInput;
        public Input FirstInput
        {
            get
            {
                return firstInput;
            }
        }

        private Input secondInput;
        public Input SecondInput
        {
            get
            {
                return secondInput;
            }
        }

        private Output output;
        public Output Output
        {
            get
            {
                return output;
            }
        }

        public LogicalAnd()
        {
            firstInput = new Input(this);
            secondInput = new Input(this);
            output = new Output();
        }

        public override void UpdateState()
        {
            output.OutputSignal = firstInput.InputSignal & secondInput.InputSignal; 
        }
    }
}
