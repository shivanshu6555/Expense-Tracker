using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseApiController : ControllerBase
    {

        private readonly ExpenseTrackerDBContext _dbContext;
        public ExpenseApiController(ExpenseTrackerDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetPaymentDetails()
        {
            return await _dbContext.Expenses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetPaymentDetails(int id)
        {
            var exp = _dbContext.Expenses.FindAsync(id);
            return Ok(exp) ;
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> PostPaymentDetails(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            await _dbContext.SaveChangesAsync();
            return Ok(expense);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Expense>> EditPaymentDetails(int id, Expense expense)
        {
            var curexpense = await _dbContext.Expenses.FindAsync(id);

            if (curexpense == null)
                return NotFound();

            curexpense.Value = expense.Value;
            curexpense.Description = expense.Description;
            curexpense.Category = expense.Category;

            await _dbContext.SaveChangesAsync();
            return Ok(curexpense);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemovePaymentDetails(int id)
        {
            var curexpense = await _dbContext.Expenses.FindAsync(id);
             _dbContext.Expenses.Remove(curexpense);
            await _dbContext.SaveChangesAsync();
            return Ok("deleted id : " + id);
        }


    }
}
