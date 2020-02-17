using System;

namespace Project.Models
{
    public abstract class LogicalLeaf : LogicalBase 
    {
        protected void UpdateState()
        {
            SetOutputSignal();

            foreach (Output output in outputs)
            {
                output.NotifyAllObservers();
            }
        }

        protected Output LeafOutput
        {
            get
            {
                return Outputs[0];
            }
        }

        protected abstract void SetOutputSignal();

        protected void SetupSignals(Int32 numberInputs)
        {
            for (Int32 i = 0; i < numberInputs; i++)
            {
                inputs.Add(new Input(new Action(UpdateState)));
            }
            Outputs.Add(new Output());
        }
    }
}
