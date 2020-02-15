using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public abstract class LogicalBase
    {
        protected readonly ObservableCollection<Input> inputs =
            new ObservableCollection<Input>();

        public  ObservableCollection<Input> Inputs
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

        protected void SetupInputs(Int32 numberInputs)
        {
            for (Int32 i = 0; i < numberInputs; i++)
            {
                inputs.Add(new Input(new Action(UpdateState)));
            }
        }
    }
}
