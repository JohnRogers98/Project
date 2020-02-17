using System;

namespace Project.Models
{
    public sealed class ShemaInput : Input
    {
        private readonly IObservable outputStateForShema = new Output();
        public IObservable OutputStateForShema
        {
            get
            {
                return outputStateForShema;
            }
        }

        public ShemaInput()
        {
            changeSignalCallback = new Action(ConnectionInternalInputToExternalOutput);
        }

        private void ConnectionInternalInputToExternalOutput()
        {
            ((Output)outputStateForShema).SignalValue = SignalValue;
            outputStateForShema.NotifyAllObservers();
        }
    }
}
