using System;

namespace Project.Models
{
    public class Input : Signal, IObserver
    {
        IObservable observable;

        protected Action changeSignalCallback;

        private Boolean isObservable;
        public Boolean IsObservable
        {
            get
            {
                return isObservable;
            }
        }

        public IObservable Observable
        {
            get
            {
                return observable;
            }
        }

        public Input(Action updateStateElement)
        {
            this.changeSignalCallback = updateStateElement;
        }

        public Input()
        {

        }


        public Boolean AttachObservable(IObservable observable)
        {
            if (isObservable == false)
            {
                InstallNewObservable(observable);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void InstallNewObservable(IObservable observable)
        {
            this.observable = observable;
            isObservable = true;
            observable.AttachObserver(this);
        }



        public void DetachObservable()
        {
            if (isObservable == true)
            {
                DeleteExistObservable();
            }
        }
        private void DeleteExistObservable()
        {
            observable.DetachObserver(this);
            observable = null;
            isObservable = false;
        }



        public void Update(Boolean signal)
        {
            SignalValue = signal;
            if (changeSignalCallback != null)
                changeSignalCallback();
        }
    }
}
