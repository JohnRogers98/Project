using Project.ViewModels;
using System.Windows.Controls;

namespace Project.Views
{
    /// <summary>
    /// Логика взаимодействия для LogicalSwitchControl.xaml
    /// </summary>
    public partial class SwitchControl : UserControl
    {
        public SwitchControl()
        {
            InitializeComponent();
            DataContext = new SwitchVM();
        }
    }
}
