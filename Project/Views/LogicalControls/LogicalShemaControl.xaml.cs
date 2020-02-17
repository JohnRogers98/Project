using Project.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Project.Views
{
    /// <summary>
    /// Логика взаимодействия для LogicalShema.xaml
    /// </summary>
    public partial class LogicalShemaControl : UserControl
    {
        public LogicalShemaControl(ObservableCollection<LogicalBaseVM> elements)
        {
            InitializeComponent();
            DataContext = LogicalBaseVM.CreateLogicalShema(elements);
        }
    }
}
