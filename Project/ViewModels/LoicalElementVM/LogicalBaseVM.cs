using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.ViewModels
{
    public abstract class LogicalBaseVM
    {
        protected LogicalBase logicalModel;

        public Boolean OutputSignal
        {
            get
            {
                return logicalModel.Output.SignalValue;
            }
        }

        private RelayCommand selectOutputCommand;
        public RelayCommand SelectOutputCommand
        {
            get
            {
                if (selectOutputCommand != null)
                    return selectOutputCommand;
                else
                    return selectOutputCommand = new RelayCommand(
                    (obj) =>
                    {
                        SelectSignal.Signal = logicalModel.Output;
                    },
                    (obj) =>
                    {
                        return true;
                    });
            }
        }

        private RelayCommand selectInputCommand;
        public RelayCommand SelectInputCommand
        {
            get
            {
                if (selectInputCommand != null)
                    return selectInputCommand;
                else
                    return selectInputCommand = new RelayCommand(
                    (obj) =>
                    {
                        Int32 numberInput = (Int32)obj;
                        SelectSignal.Signal = logicalModel.Inputs[numberInput];
                    },
                    (obj) =>
                    {
                        return true;
                    });
            }
        }
    }
}
