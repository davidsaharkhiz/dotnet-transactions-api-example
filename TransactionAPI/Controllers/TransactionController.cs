﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionAPI.Models;
using TransactionAPI.Services;
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

		}

        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

		// GET: Transaction/Details/5
		public ActionResult List()
		{

			var blah = new TransactionList(_apiService.client);

			var viewModel = new ViewModels.Transaction.TransactionListViewModel
			{
				TransactionList = new TransactionList()
			};
			return View(viewModel);
		}

	}
}
