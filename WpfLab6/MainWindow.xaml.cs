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

namespace WpfLab6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }

    class WeatherControl : DependencyObject
    {
        private string wind_direction;
        private int wind_speed;
        private Precipitation precipitation;
        public string windDirection { get; set; }
        public int windSpeed { get; set; }
        public WeatherControl(string windir, int windspeed, Precipitation precipitition)
        {
            this.windDirection = windir;
            this.windSpeed = windspeed;
            this.precipitation = precipitition;
        }
        public static readonly DependencyProperty temperatureProperty;
        static WeatherControl()
        {
            temperatureProperty = DependencyProperty.Register(
            nameof(temperature),
            typeof(int),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                FrameworkPropertyMetadataOptions.Journal,
                null,
                new CoerceValueCallback(Coercetemperature)));
        }
        private static object Coercetemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v > -50 && v < 50)
            {
                return v;
            }
            else { return 0; }
        }

        public int temperature
        {
            get => (int)GetValue(temperatureProperty);
            set => SetValue(temperatureProperty, value);
        }

    }
}
