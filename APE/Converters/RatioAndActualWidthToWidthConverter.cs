using System;
using System.Globalization;
using System.Windows.Data;

namespace APE.Converters
{
    public class RatioAndActualWidthToWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double ratio && values[1] is double actualWidth)
            {
                // Calculate the width based on the actual width of the outer border and the progress ratio
                return ratio * actualWidth;
            }
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
