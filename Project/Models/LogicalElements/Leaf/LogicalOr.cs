using System;

namespace Project.Models
{
    public class LogicalOr : LogicalLeaf
    {
        public LogicalOr(Int32 numberInputs = 2)
        {
            SetupSignals(numberInputs);
        }

        protected override void SetOutputSignal()
        {
            foreach (Input input in inputs)
            {
                if (input.SignalValue == true)
                {
                    LeafOutput.SignalValue = true;
                    return;
                }
            }

            LeafOutput.SignalValue = false;
        }
    }
}
