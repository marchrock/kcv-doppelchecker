using System;
using System.Globalization;
using System.Windows.Data;

namespace Doppelchecker.Views.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            try
            {
                var intValue = (int) value;
                return intValue != 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
