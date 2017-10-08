using System;
using System.Globalization;
using Xamarin.Forms;

namespace Ct.SubFinder.Mobile.App.ValueConverters
{
    public class SelectedItemToOpacityConverter : IValueConverter
    {
        public double _selectedOpacity = 1.0;
        public double _unselectedOpacity = 0.6;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var opacity = _unselectedOpacity;
            var postion = (int)value;
            var selectedPosition = int.Parse(parameter.ToString());

            if(postion == selectedPosition)
            {
                opacity = _selectedOpacity;
            }
            return opacity;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
