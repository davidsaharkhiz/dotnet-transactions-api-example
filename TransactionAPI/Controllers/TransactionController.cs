using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TransactionAPI.Services.APIService;

namespace TransactionAPI.Controllers
{
    public class TransactionController : Controller
    {

		private TranscardAPIService _apiService;

		/// <summary>
		/// So, I normally wouldn't do this, but I believe we were barred from using 3PL's such as Autofac or Unity, but I still wanted to leverage constructor injection of this service
		/// </summary>
		public TransactionController()
			: this(new TranscardAPIService())
		{
		}

		public TransactionController(TranscardAPIService service) {
			_apiService = service;
		}

        public ActionResult Index()
        {
            return View();
        }

		/// <summary>
		/// Displays a list of transactions and a summary by category, as well as various metrics on spending
		/// </summary>
		public ActionResult List()
		{
			var transactionList = _apiService.client.GetTransactionList();

			// Group our purchases into categories (excluding income)
			var categorySummaries = new List<ViewModels.Transaction.TransactionListViewModel.CategorySummary>();
			if (transactionList.Transactions.Any()) {
				var categories = transactionList.Transactions.Where(t => t.Amount < 0).GroupBy(t => t.Category);

				foreach (var category in categories)
				{
					var categorySummary = new ViewModels.Transaction.TransactionListViewModel.CategorySummary
					{
						CategoryName = category.First().Category,
						Sum = category.Sum(c => c.Amount) * -1 // We want to display this as absolute value
					};
					categorySummaries.Add(categorySummary);
				}

			}

			// Populate the viewmodel with the transactionlist and category lists
			var viewModel = new ViewModels.Transaction.TransactionListViewModel
			{
				TransactionList = transactionList,
				CategorySummaries = categorySummaries,
				TotalMonthlyExpenses = transactionList.Transactions.Where(t => t.Amount < 0).Sum(t => t.Amount) * -1, //We want to display this as absolute value
				TotalMonthlyIncome = transactionList.Transactions.Where(t => t.Amount > 0).Sum(t => t.Amount)
			};

			return View(viewModel);
		}

	}
}
