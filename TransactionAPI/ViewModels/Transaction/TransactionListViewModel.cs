using TransactionAPI.Models;
namespace TransactionAPI.ViewModels.Transaction
{
	public class TransactionListViewModel
	{
		public int TotalMonthlyIncome { get; set; } = 0;
		public int TotalMonthlyExpenses { get; set; } = 0;

		public ITransactionList TransactionList { get; set; }
	}
}

