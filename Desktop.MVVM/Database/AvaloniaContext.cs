using System;
using Desktop.MVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace Desktop.MVVM.Database;

public class AvaloniaContext: DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    
    public string DbPath { get; }

    public AvaloniaContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "avalonia.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}