namespace UpRestaraunt.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Конвертер, инвертирующий значение переменной bool.
    /// </summary>
    public class InversionBoolConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is IConvertible conv && conv.ToInt64(null) != 0 ? false : true;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
