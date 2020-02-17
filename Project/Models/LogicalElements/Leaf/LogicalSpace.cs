namespace Project.Models
{
    public class LogicalSpace : LogicalLeaf
    {
        public LogicalSpace()
        {
            SetupSignals(1);
        }

        protected override void SetOutputSignal()
        {
            LeafOutput.SignalValue = inputs[0].SignalValue;
        }
    }
}
