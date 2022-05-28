using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converter;

public class FilePathToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Conversion du path en string de max 10 caracteres
        string s = value as string;

        if (s.Length >= 10)
        {
            s = s.Substring(s.Length - 10, 10);
            s = "... " + s;
        }

        return s;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}