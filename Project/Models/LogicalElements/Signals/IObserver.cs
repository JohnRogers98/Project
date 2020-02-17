using System;

namespace Project.Models
{
    public interface IObserver
    {
        Boolean IsObservable { get; }
        IObservable Observable { get; }
        Boolean AttachObservable(IObservable observable);
        void DetachObservable();
        void Update(Boolean signal);
    }
}
