using System;

namespace Project.Models
{
    public class LogicalAnd : LogicalBase
    {
        public LogicalAnd(Int32 numberInputs = 2)
        {
            SetupLeafSignals(numberInputs);
        }

        protected override void SetOutputSignal()
        {
            foreach (Input input in inputs)
            {
                if (input.SignalValue == false)
                {
                    LeafOutput.SignalValue = false;
                    return;
                }
            }

            LeafOutput.SignalValue = true;
        }
    }
}
