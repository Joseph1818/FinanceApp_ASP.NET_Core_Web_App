using Microsoft.EntityFrameworkCore;
using FinancialApp.Models;

namespace FinancialApp.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options){}

        //Creating an instance for our Expense models
        public DbSet<Expense> Expenses { get; set; }

        protected FinanceAppContext()
        {

        }
    }
}
