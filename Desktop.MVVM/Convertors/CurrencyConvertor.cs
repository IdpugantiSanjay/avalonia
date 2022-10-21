using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Desktop.MVVM.Convertors;

public class CurrencyConvertor: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            decimal curr => curr.ToString("C0", new CultureInfo("en-IN")),
            int curr => curr.ToString("C0", new CultureInfo("en-IN")),
            _ => new BindingNotification(new InvalidCastException(), BindingErrorType.Error)
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}