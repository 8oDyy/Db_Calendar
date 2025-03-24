using System.Globalization;
using Microsoft.Maui.Controls;

namespace BOULICAUT_RAFFORT_Calendar.Converters;

public class BoolToTextDecorationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool fait && fait)
            return TextDecorations.Strikethrough;

        return TextDecorations.None;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}