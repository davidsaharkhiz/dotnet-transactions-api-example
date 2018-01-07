using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionAPI.Models;
using TransactionAPI.Services;
using TransactionAPI.Services.APIService;
using TransactionAPI.Helpers;
using TransactionAPI.ViewModels;

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

        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

		// GET: Transaction/Details/5
		public ActionResult List()
		{
			var transactionList = _apiService.client.GetTransactionList();
			var viewModel = new ViewModels.Transaction.TransactionListViewModel
			{
				TransactionList = transactionList,
				CategorySummaries = new List<ViewModels.Transaction.TransactionListViewModel.CategorySummary>(), //todo!!
				TotalMonthlyExpenses = transactionList.Transactions.Where(t => t.Amount < 0).Sum(t => t.Amount),
				TotalMonthlyIncome = transactionList.Transactions.Where(t => t.Amount > 0).Sum(t => t.Amount)
			};

			return View(viewModel);
		}

	}
}
