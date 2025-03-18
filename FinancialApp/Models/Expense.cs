using System.ComponentModel.DataAnnotations;

namespace FinancialApp.Models
{
    public class Expense
    {
        public int Id { set; get; }
        [Required]
        public string Description { set; get; } = null! ;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="The amount need to be higher")]
        public double Amount { set; get; }
        [Required]
        public string Category { set; get; } = null!;
        public DateTime Date { set; get; } = DateTime.Now;
    }
}
