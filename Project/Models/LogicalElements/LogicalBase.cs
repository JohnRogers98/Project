using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public abstract class LogicalBase
    {
        protected List<Input> inputs = new List<Input>();

        public  List<Input> Inputs
        {
            get
            {
                return inputs;
            }
        }

        private Output output = new Output();

        public Output Output
        {
            get
            {
                return output;
            }
        } 
        
        protected void UpdateState()
        {
            SetOutputSignal();
            Output.NotifyAllObservers();
        }

        protected abstract void SetOutputSignal();
    }
}
