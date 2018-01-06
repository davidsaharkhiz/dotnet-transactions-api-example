using TransactionAPI.Models;
namespace TransactionAPI.ViewModels.Transaction
{
	public class TransactionListViewModel
	{
		public string GrossEmployeeCompensation { get; set; }
		public int NumberOfEmployees { get; set; }
		public int NumberOfDependents { get; set; }
		public string TotalEmployeeBenefits { get; set; }
	}
}

