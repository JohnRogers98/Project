using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalSwitch : LogicalBase
    {
        private Boolean signal;
        public Boolean Signal
        {
            get
            {
                return signal;
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

        public LogicalSwitch()
        {
            signal = false;
            output = new Output();
        }

        public override void UpdateState()
        {
            Switch();
            output.OutputSignal = signal;
        }

        private void Switch()
        {
            if (signal == true)
                signal = false;
            else
                signal = true;
        }
    }
}
