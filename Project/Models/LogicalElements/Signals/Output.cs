using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Output : Signal, IObservable
    {
        List<IObserver> observers = new List<IObserver>();

        public void AttachObserver(IObserver observer)
        {
            observers.Add(observer);
            observer.Update(SignalValue);
        }

        public void DetachObserver(IObserver observer)
        {
            observers.Remove(observer);
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
