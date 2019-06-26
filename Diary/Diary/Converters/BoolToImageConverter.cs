using System;
using System.Globalization;
using Xamarin.Forms;

namespace Diary.Converters
{
    /// <summary>
    /// Конвертер bool в назваие файла изображения
    /// </summary>
    class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if (!val) return "baseline_check_box_outline_blank_black_24";
            else return "baseline_check_box_black_24";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
