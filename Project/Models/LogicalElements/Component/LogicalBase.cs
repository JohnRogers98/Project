using System;
using System.Collections.ObjectModel;

namespace Project.Models
{
    public abstract class LogicalBase
    {
        protected readonly ObservableCollection<Input> inputs =
            new ObservableCollection<Input>();

        protected readonly ObservableCollection<Output> outputs =
         new ObservableCollection<Output>();

        public ObservableCollection<Input> Inputs
        {
            get
            {
                return inputs;
            }
        }

        public ObservableCollection<Output> Outputs
        {
            get
            {
                return outputs;
            }
        }

        protected Output LeafOutput
        {
            get
            {
                return Outputs[0];
            }
        }

        protected void UpdateState()
        {
            SetOutputSignal();
            LeafOutput.NotifyAllObservers();
        }

        protected abstract void SetOutputSignal();

        protected void SetupLeafSignals(Int32 numberInputs)
        {
            for (Int32 i = 0; i < numberInputs; i++)
            {
                inputs.Add(new Input(new Action(UpdateState)));
            }
            Outputs.Add(new Output());
        }
    }
}
