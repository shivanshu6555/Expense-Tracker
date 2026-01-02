using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;
using SpendSmart.ViewModels;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpenseTrackerDBContext _context;
        private int idCounter { get; set; }
        public HomeController(ILogger<HomeController> logger, ExpenseTrackerDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses(ExpenseViewModel model)
        {
            var expenses = _context.Expenses.ToList(); // or however you get your expenses
            var viewModel = new ExpenseViewModel
            {
                ExpenseList = expenses,
                // Set other properties if needed
            };
            if (model.Expense != null)
            {
                ViewBag.Total = expenses.Where(e => e.Category == model.Expense.Category).Sum(e => e.Value);
            }
            return View(viewModel);
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                model.Id = idCounter++;
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                var expense = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expense);
            }
            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(x => x.Id == id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
