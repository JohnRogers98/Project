using Project.ViewModels;
using System;
using System.Windows.Controls;

namespace Project.Views
{
    /// <summary>
    /// Логика взаимодействия для LogicalOrControl.xaml
    /// </summary>
    public partial class LogicalOrControl : UserControl
    {
        public LogicalOrControl(Int32 numberInputs = 2)
        {
            InitializeComponent();
            DataContext = LogicalBaseVM.CreateLogicalOr(numberInputs);
        }
    }
}
