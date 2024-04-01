using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CookBook_Application_Exam.EditCookBook
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var list = value as List<string>;
            if (list == null)
                return string.Empty;

            return string.Join(", ", list); // Change the separator as needed
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || targetType == null || !targetType.IsEnum)
                return DependencyProperty.UnsetValue;

            return Enum.Parse(targetType, value.ToString());
        }

    }
}
