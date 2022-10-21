using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using Desktop.MVVM.Database;
using Desktop.MVVM.Models;
using DynamicData;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace Desktop.MVVM.ViewModels;

public class TransactionListViewModelDesignView : TransactionListViewModel
{
    public TransactionListViewModelDesignView()
    {
        Items = new ObservableCollection<TransactionViewModel>(new[]
        {
            new TransactionViewModel(
                ReactiveCommand.CreateFromTask(() => Task.FromResult(Unit.Default)))
            {
                Amount = 20, Category = "Restaurant", Description = "Little-Chef",
                DateTime = DateTimeOffset.Now
            }
        });
    }
}

public class TransactionListViewModel : ViewModelBase
{
    private readonly AvaloniaContext _context;

    private ReactiveCommand<Unit, Unit> Reload { get; }

    public class TransactionViewModel
    {
        public int Id { get; set; }

        public string Description { get; init; }

        public decimal Amount { get; init; }

        public DateTimeOffset DateTime { get; init; }

        public string Category { get; init; }

        public ReactiveCommand<TransactionViewModel, Unit> Delete { get; }

        public ReactiveCommand<Unit, Unit> Reload { get; }

        public TransactionViewModel(ReactiveCommand<Unit, Unit> reload)
        {
            Reload = reload;
            var context = new AvaloniaContext();

            var delete = (TransactionViewModel vm) =>
            {
                context.Transactions.Remove(new Transaction { Id = vm.Id });
                return context.SaveChangesAsync() as Task;
            };

            Delete = ReactiveCommand.CreateFromTask(delete);
            
            this.WhenAnyObservable(x => x.Delete).InvokeCommand(Reload);
        }
    }

    public ObservableCollection<TransactionViewModel>? Items { get; set; }

    public TransactionListViewModel()
    {
        Reload = ReactiveCommand.Create(() => Unit.Default);
        _context = new AvaloniaContext();
        Reload
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(_ => InitializeList());
        InitializeList();
    }

    private void InitializeList()
    {
        var list = _context.Transactions.Select(t => new TransactionViewModel(Reload)
        {
            Amount = t.Amount, Category = t.Category, Description = t.Description,
            DateTime = t.DateTime, Id = t.Id,
        }).ToArray();

        if (Items is null)
        {
            Items = new ObservableCollection<TransactionViewModel>(list);
        }
        else
        {
            Items.Clear();
            Items.AddRange(list);
        }
    }
}