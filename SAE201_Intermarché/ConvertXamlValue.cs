using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms.VisualStyles;

namespace SAE201_Intermarche
{
    class ConvertXamlValue : IValueConverter
    {

        public double Min { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            double width = (double)value;
         //   Console.WriteLine("value : "+value + "\nwidth : "+ width);
            return width <= Min;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
