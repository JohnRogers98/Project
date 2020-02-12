using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public abstract class Signal : INotifyPropertyChanged
    {
        private Boolean signalValue;

        public Boolean SignalValue
        {
            get
            {
                return signalValue;
            }
            set
            {
                signalValue = value;
                OnPropertyChanged("SignalValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = " ")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }
    }
}
