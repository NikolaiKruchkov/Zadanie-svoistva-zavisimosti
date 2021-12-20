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

namespace Svoistva_zavisimosti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WeatherControl f = new WeatherControl("восток", 2, 0, 20);
          
            textBlock.Text = Convert.ToString(f.Temp);

        }
    }
    class WeatherControl : DependencyObject
    {
        private string napravlenie;
        private int speed;
        private int osadki;
        public enum enosadki
        {
            Solnechno =0,
            Oblachno = 1, 
            Dogd = 2,
            Sneg = 3,
        }
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public string Napravlenie
        {
            get
            {
                return napravlenie;
            }
            set
            {
                napravlenie = value;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public int Osadki
        {
            get
            {
                return osadki;
            }
            set
            {
                if (value==0)
                {
                    osadki = (int)WeatherControl.enosadki.Solnechno;
                }

                if (value == 1)
                {
                    osadki = (int)WeatherControl.enosadki.Oblachno;
                }
                if (value == 2)
                {
                    osadki = (int)WeatherControl.enosadki.Dogd;
                }
                if (value == 3)
                {
                    osadki = (int)WeatherControl.enosadki.Sneg;
                }
            }
        }

        public static readonly DependencyProperty TempProperty =
            DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.Journal,
                null,
                new CoerceValueCallback(CoerceTemp),
                true,
                UpdateSourceTrigger.LostFocus));
        private static object CoerceTemp(DependencyObject f, object baseValue)
        {
            int v = (int)baseValue;
            if (v < 50 && v > -50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }
        public WeatherControl(string napravlenie, int speed, int osadki, int temp)
        {
            this.Napravlenie = napravlenie;
            this.Speed = speed;
            this.Temp = temp;
            this.Osadki = osadki;

        }
    }
}
