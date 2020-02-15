using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Project.Models;

namespace Project.ViewModels
{
    public class LogicalBaseVM
    {
        protected LogicalBase logicalModel;

        public Signal Output
        {
            get
            {
                return logicalModel.Output;
            }
        }

        public ObservableCollection<Signal> Inputs
        {
            get
            {
                return new ObservableCollection<Signal>(logicalModel.Inputs);
            }
        }

        public static LogicalBaseVM CreateLogicalNot()
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalNot();
            return logicalBase;
        }

        public static LogicalBaseVM CreateLogicalAnd(Int32 numberCount = 2)
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalAnd(numberCount);
            return logicalBase;
        }

        public static LogicalBaseVM CreateLogicalOr(Int32 numberCount = 2)
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalOr(numberCount);
            return logicalBase;
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
                        Int32 numberInput;

                        if (obj != null)
                        {
                            if (obj.GetType() == typeof(Int32))
                            {
                                numberInput = (Int32)obj;
                            }
                            else
                            {
                                Input input = (Input)obj;
                                numberInput = Inputs.IndexOf(input);
                            }
                            SelectSignal.Signal = logicalModel.Inputs[numberInput];
                        }
                    },
                    (obj) =>
                    {
                        return true;
                    });
            }
        }
    }
}
