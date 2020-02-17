using System;
using System.Collections.ObjectModel;

namespace Project.Models
{
    public class LogicalShema : LogicalBase
    {
        ObservableCollection<LogicalBase> incomingItems =
            new ObservableCollection<LogicalBase>();

        public LogicalShema(ObservableCollection<LogicalBase> elements)
        {
            incomingItems = elements;
            SetShemaSignals();
        }

        private void SetShemaSignals()
        {
            SetShemaInputs();
            SetShemaOutputs();
        }


        private void SetShemaInputs()
        {
            foreach (LogicalBase element in incomingItems)
            {
                foreach (IObserver input in element.Inputs)
                {
                    if (input.IsObservable == false)
                    {
                        CreateShemaInput(input);
                    }
                }
            }
        }
        private void CreateShemaInput(IObserver input)
        {
            Input shemaInput = new ShemaInput(input);
            inputs.Add(shemaInput);
        }


        private void SetShemaOutputs()
        {
            foreach (LogicalBase element in incomingItems)
            {
                foreach (IObservable output in element.Outputs)
                {
                    if (output.ObserverCount == 0)
                    {
                        CreateShemaOutput(output);
                    }
                }
            }
        }
        private void CreateShemaOutput(IObservable output)
        {
            Output shemaOutput = new ShemaOutput(output);
            outputs.Add(shemaOutput);
        }
    }
}
