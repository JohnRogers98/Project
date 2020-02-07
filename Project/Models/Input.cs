using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Input
    {
        LogicalBase logicalElement;

        private Boolean signal;

        public Boolean Signal
        {
            get
            {
                return signal;
            }
            set
            {
                signal = value;
                logicalElement.OnFinishProcessing();
            }
        }

        public Input(LogicalBase logicalElement)
        {
            this.logicalElement = logicalElement;
        }

        public void SubscribeOnEntranceSignal(LogicalBase logicalElementBase)
        {
            logicalElementBase.OutputSignalEvent += EntranceSignal;
        }

        void EntranceSignal(object sender, EventArgs e)
        {
            LogicalBase elementBase = (LogicalBase)sender;
            Signal = elementBase.OutputSignal;
        }
    }
}
