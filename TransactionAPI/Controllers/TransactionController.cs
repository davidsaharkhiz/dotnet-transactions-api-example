using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionAPI.Models;
using TransactionAPI.Services;

namespace TransactionAPI.Controllers
{
    public class TransactionController : Controller
    {

		private APIService _apiService;

		/// <summary>
		/// So, I normally wouldn't do this, but I believe we were barred from using 3PL's such as Autofac or Unity, but I still wanted to leverage constructor injection of this service
		/// </summary>
		public TransactionController()
			: this(new APIService())
		{
		}

		public TransactionController(APIService service) {
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
				TransactionList = new TransactionList()
			};
			return View(viewModel);
		}

	}
}
