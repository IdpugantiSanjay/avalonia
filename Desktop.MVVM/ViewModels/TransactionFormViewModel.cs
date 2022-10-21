using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;

namespace Desktop.MVVM.ViewModels;

public class TransactionFormViewModel: ViewModelBase
{
    [Reactive] public DateTimeOffset DateTime { get; set; } = DateTimeOffset.Now.Date;
    [Reactive] public decimal Amount { get; set; }
    [Reactive] public string Category { get; set; } = "Restaurant";
    public string Description { get; set; } = "";
    public ReactiveCommand<Unit, TransactionFormViewModel> Save { get; }
    
    public static IReadOnlyList<string> ExpenseCategories { get; set; } = new List<string>
        { "Restaurant", "Food & Drinks", "Healthcare" };

    public static IReadOnlyList<string> IncomeCategories { get; set; } =
        new List<string> { "Salary", "Refund", "Interest" };

    public TransactionFormViewModel()
    {
        this.ValidationRule(x => x.Amount, amount => amount > 0,
            "Amount should be greater than 0");
        this.ValidationRule(x => x.DateTime, offset => offset.Date <= DateTimeOffset.Now.Date,
            "DateTime cannot be greater than today's date");

        Save = ReactiveCommand.CreateFromTask(
            () =>
            {
                return Task.Run(() =>  this);
            },
            this.IsValid());
    }
}