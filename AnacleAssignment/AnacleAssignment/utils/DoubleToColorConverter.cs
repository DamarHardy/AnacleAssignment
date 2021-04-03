using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AnacleAssignment.utils
{
    class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                double temp = (double)value;
                if(temp < 37.5)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Red;
                }
            }
            else
            {
                return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Green;
        }
    }
}
