using System;

namespace Project.Models
{
    public class LogicalOr : LogicalBase
    {
        public LogicalOr(Int32 numberInputs = 2)
        {
            SetupLeafSignals(numberInputs);
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
