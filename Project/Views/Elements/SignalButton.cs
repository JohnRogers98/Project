using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Project.Views
{
    public class SignalButton : Button
    {
        public static readonly DependencyProperty SignalValueProperty;
      
        public Boolean SignalValue
        {
            get
            {
                return (Boolean)GetValue(SignalValueProperty);
            }
            set 
            {
                SetValue(SignalValueProperty, value);
            }
        }

        static SignalButton()
        {
            FrameworkPropertyMetadata meta = new FrameworkPropertyMetadata(
                false, new PropertyChangedCallback(SignalValuePropertyCallback));

            SignalValueProperty = DependencyProperty.Register(
                "SignalValue", typeof(Boolean), typeof(SignalButton), meta);
        }

        public SignalButton()
        {
            MinWidth = 30;
            MaxWidth = 50;
            MinHeight = 30;
            MaxHeight = 50;
            Background = Brushes.Red;
        }

        public Boolean SignalIsOutput
        {
            set
            {
                if (value == true)
                    AcceptOutputPosition();
                else
                    AcceptInputPosition();
            }
        }

        private void AcceptOutputPosition()
        {
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Center;
        }

        private void AcceptInputPosition()
        {
            this.HorizontalAlignment = HorizontalAlignment.Right;
            this.VerticalAlignment = VerticalAlignment.Center;
        }

        private static void SignalValuePropertyCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            SignalButton signalButton = (SignalButton)obj;
            Boolean signal = (Boolean)e.NewValue;

            SetColor(signal, signalButton);
        }

        private static void SetColor(Boolean signal, SignalButton signalButton)
        {
            if (signal == true)
                signalButton.Background = Brushes.Green;
            else
                signalButton.Background = Brushes.Red;
        }
    }
}
