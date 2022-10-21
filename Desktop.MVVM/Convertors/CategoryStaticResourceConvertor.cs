using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Desktop.MVVM.Convertors;

public class CategoryStaticResourceConvertor: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Application.Current?.FindResource(value switch
        {
            "Food & Drinks" => "FoodIcon",
            "Restaurant" => "RestaurantIcon",
            "Healthcare" => "HealthcareIcon",
            "Salary" => "SalaryIcon",
            "Interest" => "InterestIcon",
            "Refund" => "RefundIcon",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        });
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}