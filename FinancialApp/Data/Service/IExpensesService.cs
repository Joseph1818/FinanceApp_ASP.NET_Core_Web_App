using FinancialApp.Models;

namespace FinancialApp.Data.Service

{
    public interface IExpensesService
    {
        // Methods signature
        Task<IEnumerable<Expense>> GetAll();

        Task Add(Expense expense);

        IQueryable GetChartData();

    }
}
