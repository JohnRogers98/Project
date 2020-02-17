using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Project.Views
{
    [ValueConversion(typeof(Boolean), typeof(SolidColorBrush))]
    public class SignalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Boolean signal = (Boolean)value;
            if (signal == true)
                return Brushes.Green;
            else
                return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
