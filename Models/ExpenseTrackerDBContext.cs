using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    public class ExpenseTrackerDBContext : DbContext
    {

        public DbSet<Expense> Expenses { get; set; }
        public ExpenseTrackerDBContext(DbContextOptions<ExpenseTrackerDBContext> options)
            : base(options)
        {
              
        }
    }
}
