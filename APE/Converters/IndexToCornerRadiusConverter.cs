using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System;

namespace APE.Converters
{
    public class IndexToCornerRadiusConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const int R = 5;
            int index = (int)value;
            int count = (int)parameter;

            // If there is only one bar left and right need to be rounded.

            if (count == 1)
            {
                return new CornerRadius(R, R, R, R);
            }

            // Handle the start, middle, and end bar shapes 
            // The start (index == 0) progress bar should be rounded on the left side
            // The middle (index != 0 or index != count -1) should be a rectangle
            // The last (index == count - 1) should be rounded on the right side
            if (index == 0)
            {
                return new CornerRadius(R, 0, 0, R);
            }
            else if (index == count - 1)
            {
                return new CornerRadius(0, R, R, 0);
            }
            else
            {
                return new CornerRadius(0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
