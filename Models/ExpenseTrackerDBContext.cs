using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    public class ExpenseTrackerDBContext : DbContext
    {

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().Property(e => e.Category).HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
        public ExpenseTrackerDBContext(DbContextOptions<ExpenseTrackerDBContext> options)
            : base(options)
        {
              
        }
    }
}
