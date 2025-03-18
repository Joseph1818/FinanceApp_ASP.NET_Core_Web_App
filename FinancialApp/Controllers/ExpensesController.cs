using Microsoft.AspNetCore.Mvc;
using FinancialApp.Data;

namespace FinancialApp.Controllers
{
    public class ExpensesController : Controller
    {
        // Variable with the type of Icontext This will communicate with the database
        private readonly FinanceAppContext _context;

        //Constructor 
        public ExpensesController(FinanceAppContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
