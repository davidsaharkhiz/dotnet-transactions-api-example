using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionAPI.Models;
using TransactionAPI.Services;
using TransactionAPI.Services.APIService;
using TransactionAPI.Helpers;

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
			var viewModel = new ViewModels.Transaction.TransactionListViewModel
			{
				TransactionList = _apiService.client.GetTransactionList()
			};

			return View(viewModel);
		}

	}
}
