using Microsoft.AspNetCore.Mvc;
using FinancialApp.Data;
using FinancialApp.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Controllers
{
    public class ExpensesController : Controller
    {
        // Creating access to the context we created so we can be able to interact with the database;
        // We will be using "_context" this variable to interact with our database
       public readonly FinanceAppContext _context;
        // Creating a constructor as a dependancy
        public ExpensesController(FinanceAppContext context)
        {
            _context = context;
        }
       //This action Method returns Index
       public async Task <IActionResult> Index()
        {
            //Taking our data from the database the value we are getting from the database is passed to the variable
            //exepenses. and we are returning it into the view
            var expenses = await _context.Expenses.ToListAsync();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        // This action Method returns A create page and the actions happening init
        [HttpPost]
        public async Task <IActionResult> Create(Expense expense)
        {
            // what is happening is that if the expense is valid we save it into our database.
            // Then we redirect into the view.
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }
            return View(expense);
        }
    }
}
