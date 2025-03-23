using FinancialApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FinancialApp.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        // Creating access to the context we created so we can be able to interact with the database;
        // We will be using "_context" this variable to interact with our database
        
        private readonly FinanceAppContext _context;

        // A contrusctor to access the Context
       public ExpensesService (FinanceAppContext context)
        {
            _context = context;
        }

        // Into this method we need to perfom the operation we were perfoming in our controller
        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }
        // Get data from the datbase
        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public  IQueryable GetChartData()
        {
            var data = _context.Expenses
                                .GroupBy(e => e.Category)
                                .Select(g => new {
                                                Category = g.Key,
                                                Total = g.Sum(e => e.Amount) });

            return data;
                                        
        }
       
    }
}
