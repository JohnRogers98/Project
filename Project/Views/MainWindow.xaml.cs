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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void LogicalHitMouseLeftButtonDownOnTish(object sender, MouseButtonEventArgs e)
        {
            Point coordinateMouse = e.GetPosition(logicalElementsTish);

            LogicalElementAndControl rectangle = new LogicalElementAndControl();
            rectangle.Focusable = true;
            rectangle.Height = 100;
            rectangle.Width = 200;
            Canvas.SetLeft(rectangle, coordinateMouse.X);
            Canvas.SetTop(rectangle, coordinateMouse.Y);

                logicalElementsTish.Children.Add(rectangle);
                
        }
    }
}
