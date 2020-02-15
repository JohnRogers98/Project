using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.ViewModels;

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
