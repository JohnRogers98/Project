namespace Project.Models
{
    public class LogicalNot : LogicalLeaf
    {
        public LogicalNot()
        {
            SetupSignals(1);
        }

        protected override void SetOutputSignal()
        {
            LeafOutput.SignalValue = !inputs[0].SignalValue;
        }
    }
}
