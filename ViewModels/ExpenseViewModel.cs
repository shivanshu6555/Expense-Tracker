using SpendSmart.Models;

namespace SpendSmart.ViewModels
{
    public class ExpenseViewModel
    {
        public Expense? Expense { get; set; }
        public List<Expense>? ExpenseList{get; set;}

        public ExpenseCategories Category { get; set; }
    }
}
