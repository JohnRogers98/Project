using System;

namespace Project.Models
{
    public sealed class ShemaOutput : Output
    {
        private readonly IObserver inputStateForShema;

        public IObserver InputStateForShema
        {
            get
            {
                return inputStateForShema;
            }
        }

        public ShemaOutput()
        {
            inputStateForShema = new Input(new Action(ConnectionInternalOutputToExternalInput));
        }

        private void ConnectionInternalOutputToExternalInput()
        {
            this.SignalValue = ((Input)inputStateForShema).SignalValue;
            this.NotifyAllObservers();
        }
    }
}
