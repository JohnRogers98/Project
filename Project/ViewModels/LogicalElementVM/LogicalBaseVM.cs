using Project.Models;
using System;
using System.Collections.ObjectModel;

namespace Project.ViewModels
{
    public class LogicalBaseVM
    {
        protected LogicalBase logicalModel;

        public ObservableCollection<Signal> OutputSignals
        {
            get
            {
                return new ObservableCollection<Signal>(logicalModel.Outputs);
            }
        }

        public ObservableCollection<Signal> InputSignals
        {
            get
            {
                return new ObservableCollection<Signal>(logicalModel.Inputs);
            }
        }

        private RelayCommand selectSignalCommand;
        public RelayCommand SelectSignalCommand
        {
            get
            {
                if (selectSignalCommand != null)
                    return selectSignalCommand;
                else
                    return selectSignalCommand = new RelayCommand(
                    (obj) =>
                    {
                        Signal signal = (Signal)obj;
                        SelectSignal.Signal = signal;
                    },
                    (obj) =>
                    {
                        return true;
                    });
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

        public static LogicalBaseVM CreateLogicalSpace()
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalSpace();
            return logicalBase;
        }

        public static LogicalBaseVM CreateLogicalShema(ObservableCollection<LogicalBase> elements)
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalShema(elements);
            return logicalBase;
        }
        public static LogicalBaseVM CreateLogicalShema(ObservableCollection<LogicalBaseVM> elements)
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();

            logicalBase.logicalModel = new LogicalShema(
                ConvertCollectionBaseVMToBaseModel(elements)
                );
            return logicalBase;
        }
        
        private static ObservableCollection<LogicalBase> ConvertCollectionBaseVMToBaseModel(
            ObservableCollection<LogicalBaseVM> VMElements)
        {
            ObservableCollection<LogicalBase> modelElements =
                new ObservableCollection<LogicalBase>();

            foreach (LogicalBaseVM element in VMElements)
            {
                modelElements.Add(element);
            }
            return modelElements;
        }

        public static implicit operator LogicalBase(LogicalBaseVM vm)
        {
            return vm.logicalModel;
        }
    }
}
