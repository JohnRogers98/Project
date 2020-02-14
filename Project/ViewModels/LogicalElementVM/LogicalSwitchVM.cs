using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.ViewModels
{
    public class LogicalSwitchVM
    {
        LogicalSwitch switchModel;

        public Signal Output
        {
            get
            {
                return switchModel.Output;
            }
        }

        public LogicalSwitchVM()
        {
            switchModel = new LogicalSwitch();
        }

        private RelayCommand switchingCommand;
        public RelayCommand SwitchingCommand
        {
            get
            {
                if (switchingCommand != null)
                    return switchingCommand;
                else
                    return switchingCommand = new RelayCommand(
                    (obj) =>
                    {
                        switchModel.Switching();
                    },
                    (obj) =>
                    {
                        return true;
                    });
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
                        SelectSignal.Signal = switchModel.Output;
                    },
                    (obj) =>
                    {
                        return true;
                    });
            }
        }
    }
}
