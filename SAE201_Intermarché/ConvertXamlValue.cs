using System;
using System.Globalization;
using System.Windows.Data;

namespace SAE201_Intermarche
{
    internal class ConvertXamlValue : IValueConverter
    {

        public double Min { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            double width = (double)value;
            //Console.WriteLine("value : "+value + "\nwidth : "+ width);
            return width <= Min;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
