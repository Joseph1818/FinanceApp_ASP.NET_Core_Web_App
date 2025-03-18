using Microsoft.EntityFrameworkCore;
using FinancialApp.Models;

namespace FinancialApp.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options){}

        //Creating an instance for our Expense models
        DbSet<Expense> Expesenses { set; get; }

        protected FinanceAppContext()
        {
        }
    }
}
