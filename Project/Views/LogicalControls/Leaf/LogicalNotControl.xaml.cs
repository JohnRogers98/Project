using Project.ViewModels;
using System.Windows.Controls;

namespace Project.Views
{
    /// <summary>
    /// Логика взаимодействия для LogicalNotControl.xaml
    /// </summary>
    public partial class LogicalNotControl : UserControl
    {
        public LogicalNotControl()
        {
            InitializeComponent();

            DataContext = LogicalBaseVM.CreateLogicalNot();
        }
    }
}
