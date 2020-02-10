using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Input : IObserver
    {
        LogicalBase logicalElement;

        private Boolean inputSignal;

        public Boolean InputSignal
        {
            get
            {
                return inputSignal;
            }
            private set
            {
                inputSignal = value;
                logicalElement.UpdateState();
            }
        }

        public Input(LogicalBase logicalElement)
        {
            this.logicalElement = logicalElement;
        }

        public void Update(Boolean signal)
        {
            InputSignal = signal;   
        }
    }
}
