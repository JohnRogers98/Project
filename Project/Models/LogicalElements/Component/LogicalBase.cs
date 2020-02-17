using System;
using System.Collections.ObjectModel;

namespace Project.Models
{
    public abstract class LogicalBase
    {
        protected readonly ObservableCollection<Input> inputs =
            new ObservableCollection<Input>();

        public ObservableCollection<Input> Inputs
        {
            get
            {
                return inputs;
            }
        }


        protected readonly ObservableCollection<Output> outputs =
         new ObservableCollection<Output>();

        public ObservableCollection<Output> Outputs
        {
            get
            {
                return outputs;
            }
        }
    }
}
