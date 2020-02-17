using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class Output : Signal, IObservable
    {
        List<IObserver> observers = new List<IObserver>();

        private Int32 observerCount;
        public Int32 ObserverCount
        {
            get
            {
                return observerCount;
            }
        }

        public Boolean AttachObserver(IObserver observer)
        {
            if (observer.IsObservable == false)
            {
                AddNewObserver(observer);
                observer.AttachObservable(this);
                return true;
            }
            else
            {
                if (observer.Observable == this)
                {
                    if (observers.Contains(observer) == false)
                    {
                        AddNewObserver(observer);
                        return true;
                    }
                }
                return false;
            }
        }
        public void AddNewObserver(IObserver observer)
        {
            observers.Add(observer);
            observerCount++;
            observer.Update(SignalValue);
        }



        public void DetachObserver(IObserver observer)
        {
            if (observers.Remove(observer) == true)
            {
                observerCount--;
                observer.DetachObservable();
            }
        }



        public void NotifyAllObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(SignalValue);
            }
        }
    }
}
