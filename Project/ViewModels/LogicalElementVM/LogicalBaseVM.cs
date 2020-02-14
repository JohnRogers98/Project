using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Signal> Inputs
        {
            get
            {
                return new List<Signal>(logicalModel.Inputs);
            }
        }

        public static LogicalBaseVM CreateLogicalNot()
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalNot();
            return logicalBase;
        }

        public static LogicalBaseVM CreateLogicalAnd()
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalAnd();
            return logicalBase;
        }

        public static LogicalBaseVM CreateLogicalOr()
        {
            LogicalBaseVM logicalBase = new LogicalBaseVM();
            logicalBase.logicalModel = new LogicalOr();
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
                            if (obj.GetType() == typeof(String))
                            {
                                numberInput = Convert.ToInt32((String)obj);
                            }
                            else
                            {
                                numberInput = (Int32)obj;
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
