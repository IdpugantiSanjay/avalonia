using System;

namespace Desktop.MVVM.Models;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset DateTime { get; set; }
    public string Category { get; set; } = string.Empty;
}