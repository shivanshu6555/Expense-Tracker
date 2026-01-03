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
    }
}
