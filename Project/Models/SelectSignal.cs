using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public static class SelectSignal
    {
        private static Signal signal;

        public static Signal Signal
        {
            set
            {
                if (SelectSignal.signal == null || SelectSignal.signal.GetType() == value.GetType())
                {
                    SelectSignal.signal = value;
                }
                else
                {
                    if(signal.GetType() == typeof(Output))
                        ((Output)signal).AttachObserver((Input)value);
                    else
                        ((Output)value).AttachObserver((Input)signal);
                    SelectSignal.signal = null;
                }
            }
        }
    }
}
