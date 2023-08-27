using System;
using System.Globalization;
using System.Windows.Data;

namespace FunctionApp.Converters
{
    /// <summary>
    /// Конвертер для деления вещественного числа на целое число.
    /// </summary>
    public class DivisionConverter : IValueConverter
    {
        /// <summary>
        /// Делит вещественное число на целое число.
        /// </summary>
        /// <param name="value">Вещественное число.</param>
        /// <param name="targetType">Тип целевого свойства привязки.</param>
        /// <param name="parameter">Целое число.</param>
        /// <param name="culture">Культура для использования в конвертере.</param>
        /// <returns>Вещественное число.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / int.Parse(parameter.ToString()!);
        }

        /// <summary>
        /// Не реализовано.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
