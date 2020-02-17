using Project.Models;

namespace Project.ViewModels
{
    public class SwitchVM
    {
        readonly Switch switchModel;

        public Signal Output
        {
            get
            {
                return switchModel.Output;
            }
        }

        public SwitchVM()
        {
            switchModel = new Switch();
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
