namespace UpRestaraunt.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Конвертер, определяющий, отображать или скрывать объект.
    /// </summary>
    public class VisibleOrHiddenConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is IConvertible conv && conv.ToInt64(null) != 0 ? Visibility.Visible : Visibility.Hidden;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
