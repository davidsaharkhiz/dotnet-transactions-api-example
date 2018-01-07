using TransactionAPI.Models;
using System.Collections.Generic;

namespace TransactionAPI.ViewModels.Transaction
{
	public class TransactionListViewModel
	{

		public struct CategorySummary {
			public string CategoryName;
			public decimal Sum;
		}

		public decimal TotalMonthlyIncome { get; set; } = 0;
		public decimal TotalMonthlyExpenses { get; set; } = 0;

		public ITransactionList TransactionList { get; set; }

		public List<CategorySummary> CategorySummaries { get; set; }
	}
}

