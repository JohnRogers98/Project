using System;

namespace Project.Models
{
    public interface IObservable
    {
        Int32 ObserverCount { get; }
        Boolean AttachObserver(IObserver observer);
        void DetachObserver(IObserver observer);
        void NotifyAllObservers();
    }
}
