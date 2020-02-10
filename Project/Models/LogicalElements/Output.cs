using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Output : IObservable
    {
        List<IObserver> observers = new List<IObserver>();

        public void AttachObserver(IObserver observer)
        {
            observers.Add(observer);
            observer.Update(outputSignal);
        }

        public void DetachObserver(IObserver observer)
        {
            foreach (IObserver availableObserver in observers)
            {
                observers.Remove(observer);
            }
        }

        public void NotifyAllObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(outputSignal);
            }
        }

        private Boolean outputSignal;
        public  Boolean OutputSignal
        {
            get
            {
                return outputSignal;
            }
            set
            {
                outputSignal = value;
                NotifyAllObservers();
            }
        }
    }
}
