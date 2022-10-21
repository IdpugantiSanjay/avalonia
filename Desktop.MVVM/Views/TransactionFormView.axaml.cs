using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Desktop.MVVM.ViewModels;

namespace Desktop.MVVM.Views;

public partial class TransactionFormView : UserControl
{
    public TransactionFormView()
    {
        InitializeComponent();
        
        var amountTextBox = this.FindControl<TextBox>("AmountTextBox");
        if (amountTextBox != null)
        {
            amountTextBox.AttachedToVisualTree += (_, _) => amountTextBox.Focus();
        }
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void CheckboxChecked(object? sender, RoutedEventArgs e)
    {
        var categoriesCombobox = this.FindControl<ComboBox>("Category");
        if (categoriesCombobox is not null)
        {
            categoriesCombobox.Items = TransactionFormViewModel.IncomeCategories;
        }
    }

    private void CheckboxUnchecked(object? sender, RoutedEventArgs e)
    {
        var categoriesCombobox = this.FindControl<ComboBox>("Category");
        if (categoriesCombobox is not null)
        {
            categoriesCombobox.Items = TransactionFormViewModel.ExpenseCategories;
        }
    }

    private void ForwardButtonClick(object? sender, RoutedEventArgs e)
    {
        
    }
}