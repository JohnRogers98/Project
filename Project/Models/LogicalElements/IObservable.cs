using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface IObservable
    {
        void AttachObserver(IObserver observer);
        void DetachObserver(IObserver observer);
        void NotifyAllObservers();
    }
}
