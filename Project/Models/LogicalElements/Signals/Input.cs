using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Input : Signal, IObserver
    {
        private Action updateStateElement;

        public Input(Action updateStateElement)
        {
            this.updateStateElement = updateStateElement;
        }

        public void Update(Boolean signal)
        {
            SignalValue = signal;
            updateStateElement();
        }
    }
}
