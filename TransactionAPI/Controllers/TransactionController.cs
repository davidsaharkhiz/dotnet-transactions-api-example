using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionAPI.Models;

namespace TransactionAPI.Controllers
{
    public class TransactionController : Controller
    {
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
