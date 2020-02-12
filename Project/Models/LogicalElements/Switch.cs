using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalSwitch
    {
        private Boolean signal;

        private Output output = new Output(); 
        public Output Output
        {
            get
            {
                return output;
            }
        }

        public void Switching()
        {
            if (signal == true)
                signal = false;
            else
                signal = true;

            Output.SignalValue = signal;
            Output.NotifyAllObservers();
        }
    }
}
