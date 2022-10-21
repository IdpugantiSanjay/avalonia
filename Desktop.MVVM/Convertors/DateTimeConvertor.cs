using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Desktop.MVVM.Convertors;

public class DateTimeConvertor: IValueConverter
{
    public static readonly DateTimeConvertor Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter,
        CultureInfo cultureInfo)
    {
        return value switch
        {
            DateTime dateTime => dateTime.ToString("yy-MMM-dd ddd"),
            DateTimeOffset dateTime => dateTime.ToString("yy-MMM-dd ddd"),
            _ => new BindingNotification(new InvalidCastException(), BindingErrorType.Error)
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}