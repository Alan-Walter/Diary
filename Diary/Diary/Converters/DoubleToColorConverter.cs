using System;
using System.Globalization;
using Xamarin.Forms;

namespace Diary.Converters
{
    class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val = (double)value;
            if (val < 0) return Color.Red;
            else if (val == 0) return Color.Black;
            else return Color.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
