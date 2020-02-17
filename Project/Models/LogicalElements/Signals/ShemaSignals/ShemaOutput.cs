using System;

namespace Project.Models
{
    public sealed class ShemaOutput : Output
    {
        readonly IObserver inputState;

        public ShemaOutput(IObservable observable)
        {
            inputState = new Input(new Action(OutputAcceptSignalCallback));
            inputState.AttachObservable(observable);
        }

        private void OutputAcceptSignalCallback()
        {
            SignalValue = ((Signal)inputState).SignalValue;
            NotifyAllObservers();
        }
    }
}
