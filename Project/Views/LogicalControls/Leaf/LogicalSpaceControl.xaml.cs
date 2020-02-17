using Project.ViewModels;
using System.Windows.Controls;

namespace Project.Views
{
    /// <summary>
    /// Логика взаимодействия для LogicalSpaceControl.xaml
    /// </summary>
    public partial class LogicalSpaceControl : UserControl
    {
        public LogicalSpaceControl()
        {
            InitializeComponent();
            DataContext = LogicalBaseVM.CreateLogicalSpace();
        }
    }
}
