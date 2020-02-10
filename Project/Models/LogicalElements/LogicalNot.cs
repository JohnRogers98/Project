using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalNot : LogicalBase
    {
        private Input input;
        public Input Input
        {
            get
            {
                return input;
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

        public LogicalNot()
        {
            input = new Input(this);
            output = new Output();
        }

        public override void UpdateState()
        {
            output.OutputSignal = !input.InputSignal;
        }
    }
}
