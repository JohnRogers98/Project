using Project.Models;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class LogicalAndViewModel
    {
        public LogicalAnd ModelAnd { get; set; }
        public LogicalAndControl ControlAnd { get; set; }

        public LogicalAndViewModel(LogicalAndControl control)
        {
            ControlAnd = control;
        }

        //private RelayCommand addPathToFirstInput;
        //public RelayCommand AddPathToFirstInput
        //{
        //    get
        //    {
        //        //if (addPathToFirstInput != null)
        //        //    return addPathToFirstInput;
        //        //else
        //        //    return addPathToFirstInput = new RelayCommand(
        //        //    (obj) =>
        //        //    {
        //        //        if (MainWindowViewModel.selectedLogicalBase != null)
        //        //            ModelAnd.firstInput.SubscribeOnEntranceSignal(MainWindowViewModel.selectedLogicalBase);
        //        //    },
        //        //    (obj) =>
        //        //    {
        //        //        return true;
        //        //    });
        //    }
        //}

        //private RelayCommand addPathToSecondInput;
        //public RelayCommand AddPathToSecondInput
        //{
        //    get
        //    {
        //        if (addPathToSecondInput != null)
        //            return addPathToSecondInput;
        //        else
        //            return addPathToSecondInput = new RelayCommand(
        //            (obj) =>
        //            {
        //                if(MainWindowViewModel.selectedLogicalBase != null)
        //                    ModelAnd.secondInput.SubscribeOnEntranceSignal(MainWindowViewModel.selectedLogicalBase);
        //            },
        //            (obj) =>
        //            {
        //                return true;
        //            });
        //    }
        //}

        private RelayCommand outputPath;
        public RelayCommand OutputPath
        {
            get
            {
                if (outputPath != null)
                    return outputPath;
                else
                    return outputPath = new RelayCommand(
                    (obj) =>
                    {
                        MainWindowViewModel.selectedLogicalBase = ModelAnd;
                    },
                    (obj) =>
                    {
                        return true;
                    });
            }
        }
    }
}
