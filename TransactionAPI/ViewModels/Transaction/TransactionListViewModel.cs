using TransactionAPI.Models;
namespace TransactionAPI.ViewModels.Transaction
{
	public class TransactionListViewModel
	{
		public string GrossEmployeeCompensation { get; set; } = "0";
		public int NumberOfEmployees { get; set; } = 0;
		public int NumberOfDependents { get; set; } = 0;
		public string TotalEmployeeBenefits { get; set; } = "0";

		public ITransactionList TransactionList { get; set; }
	}
}

