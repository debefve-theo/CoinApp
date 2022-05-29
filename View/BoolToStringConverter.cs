using System;
using System.Globalization;
using System.Windows.Data;

namespace View
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s;

            if (value is true)
            {
                return s = "Vente";
            }
            else
            {
                return s = "Achat";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

