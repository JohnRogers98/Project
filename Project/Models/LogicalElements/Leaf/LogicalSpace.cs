namespace Project.Models
{
    public class LogicalSpace : LogicalBase
    {
        public LogicalSpace()
        {
            SetupLeafSignals(1);
        }

        protected override void SetOutputSignal()
        {
            LeafOutput.SignalValue = inputs[0].SignalValue;
        }
    }
}
