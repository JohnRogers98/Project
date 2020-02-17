using System;

namespace Project.Models
{
    public class Switch
    {
        private Boolean signal;

        private readonly Output output = new Output();

        public Output Output
        {
            get
            {
                return output;
            }
        }

        public void Switching()
        {
            if (signal == true)
                signal = false;
            else
                signal = true;

            Output.SignalValue = signal;
            Output.NotifyAllObservers();
        }
    }
}
