using System;

namespace Project.Models
{
    public sealed class ShemaInput : Input
    {
        readonly IObservable outputState = new Output();

        public ShemaInput(IObserver observer)
        {
            outputState.AttachObserver(observer);
            changeSignalCallback = new Action(InputAcceptSignalCallback);
        }

        private void InputAcceptSignalCallback()
        {
            ((Signal)outputState).SignalValue = SignalValue;
            outputState.NotifyAllObservers();
        }
    }
}
