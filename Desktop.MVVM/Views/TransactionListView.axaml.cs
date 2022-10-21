using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Desktop.MVVM.Views;

public partial class TransactionListView : UserControl
{
    public TransactionListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void DeleteTransaction(object? sender, RoutedEventArgs e)
    {
        
    }
}