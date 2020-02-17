using System;
using System.ComponentModel;

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
                OnPropertyChanged(new PropertyChangedEventArgs("SignalValue"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
