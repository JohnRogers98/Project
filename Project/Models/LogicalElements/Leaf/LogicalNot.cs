namespace Project.Models
{
    public class LogicalNot : LogicalBase
    {
        public LogicalNot()
        {
            SetupLeafSignals(1);
        }

        protected override void SetOutputSignal()
        {
            LeafOutput.SignalValue = !inputs[0].SignalValue;
        }
    }
}
