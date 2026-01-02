using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public enum ExpenseCategories
    {

        Health,
        Groceries,
        Travel,
        Wants,
        Rent,
        Maid,
        Subscription,
        Lent,
        Other
    }
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public double Value {  get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public ExpenseCategories Category { get; set; }
    }
}
