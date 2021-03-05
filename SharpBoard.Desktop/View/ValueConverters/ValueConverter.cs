using System;
using System.Globalization;
using System.Windows.Data;

namespace SharpBoard.Desktop.View.ValueConverters
{
    public abstract class ValueConverter<TSource, TTarget> : IValueConverter
        where TSource : notnull
        where TTarget : notnull
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            if (value is not TSource source) throw new ArgumentException($"Argument is of wrong type. Expected {typeof(TSource).FullName!} got {targetType.FullName!}", nameof(value));

            return Convert(source);
        }

        protected abstract TTarget Convert(TSource source);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            if (value is not TTarget source) throw new ArgumentException($"Argument is of wrong type. Expected {typeof(TSource).FullName!} got {targetType.FullName!}", nameof(value));

            return ConvertBack(source);
        }

        protected abstract TSource ConvertBack(TTarget value);
    }
}
