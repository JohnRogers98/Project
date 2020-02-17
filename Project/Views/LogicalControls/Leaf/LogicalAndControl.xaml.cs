using Project.ViewModels;
using System;
using System.Windows.Controls;

namespace Project.Views
{
    /// <summary>
    /// Логика взаимодействия для LogicalElementAndControl.xaml
    /// </summary>
    public partial class LogicalAndControl : UserControl
    {
        public LogicalAndControl(Int32 numberInputs = 2)
        {
            InitializeComponent();
            DataContext = LogicalBaseVM.CreateLogicalAnd(numberInputs);
        }
    }
}
