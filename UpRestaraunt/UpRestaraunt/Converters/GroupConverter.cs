namespace UpRestaraunt.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// Конвертер, в котором можно вызвать несколько конвертеров.
    /// </summary>
    public class GroupConverter : ItemsControl, IValueConverter
    {
        /// <summary>
        /// Все конвертеры, которые будут использоваться при конвертации.
        /// </summary>
        private List<IValueConverter> _valueConverters { get; set; }

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertingValue = value;
            foreach (var valueConverter in _valueConverters)
            {
                convertingValue = valueConverter.Convert(convertingValue, targetType, parameter, culture);
            }

            return convertingValue;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public override void EndInit()
        {
            _valueConverters = LogicalTreeHelper.GetChildren(this).Cast<IValueConverter>().ToList();
            base.EndInit();
        }
    }
}