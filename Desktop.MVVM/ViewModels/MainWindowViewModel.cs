using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using Desktop.MVVM.Database;
using Desktop.MVVM.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;

namespace Desktop.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MainWindowViewModel()
        {
            var vm = new TransactionFormViewModel();
            Content = vm;

            Observable.Merge(vm.Save).Subscribe(OnNext);
        }

        private async void OnNext(TransactionFormViewModel model)
        {
            var context = new AvaloniaContext();
            context.Transactions.Add(new Transaction { Amount = model.Amount, Category = model.Category, Description = model.Description, DateTime = model.DateTime });
            await context.SaveChangesAsync();
            Content = new TransactionListViewModel();
        }


        public void Forward()
        {
            Content = new TransactionListViewModel();
        }

        public void Backward()
        {
            Content = new TransactionFormViewModel();
        }
    }
}