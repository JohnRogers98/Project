using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public abstract class Output
    {
        public abstract Boolean OutputSignal { get; }

        public event EventHandler OutputSignalEvent;

        public virtual void OnFinishProcessing()
        {
            EventHandler eventHandler = OutputSignalEvent;
            if (eventHandler != null)
                eventHandler(this, EventArgs.Empty);
        }
    }
}
