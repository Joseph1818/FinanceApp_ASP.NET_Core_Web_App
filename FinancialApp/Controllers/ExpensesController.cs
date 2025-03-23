using Microsoft.AspNetCore.Mvc;
using FinancialApp.Data;
using FinancialApp.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.EntityFrameworkCore;
using FinancialApp.Data.Service;

namespace FinancialApp.Controllers
{
    public class ExpensesController : Controller
    {
        //Create an _expensiveService in the controller which communicate directly with the controller class.
        public readonly IExpensesService _expensesService;
        // Creating a constructor as a dependancy
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
       //This action Method returns Index
       public async Task <IActionResult> Index()
        {
            // In the controller we call the service Method with "_expensises" then call the method.
            var expenses = await _expensesService.GetAll();
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
                await _expensesService.Add(expense);
              
                return RedirectToAction("index");
            }
            return View(expense);
        }
        // Quering the data
        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
