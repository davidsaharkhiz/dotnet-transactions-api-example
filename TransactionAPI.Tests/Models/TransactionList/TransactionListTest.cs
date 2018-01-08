using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TransactionAPI.Models;

namespace TransactionAPI.Tests.Services.APIClient.Transcard
{

	[TestClass]
	public class TransactionListTest
	{

		[TestMethod]
		public void TransactionListConstructor()
		{
			var transationList = new TransactionList();
		}

		[TestMethod]
		public void TransactionListAlternateConstructorNoData()
		{
			var simulatedAPIData = new Dictionary<string, List<string>>();
			var transationList = new TransactionList(simulatedAPIData);

			Assert.IsTrue(transationList.Transactions.Count == 0);

		}

		[TestMethod]
		public void TransactionListAlternateConstructorWithData()
		{
			var simulatedAPIData = new Dictionary<string, List<string>>()
			{
				{ "Amount", new List<string> { "100" } },
				{ "Date Posted", new List<string> { "06/02/1986" } },
				{ "Transaction ID", new List<string> { "2342342fdd" } },
				{ "Status", new List<string> { "COMPLETE" } },
				{ "Category", new List<string> { "Fishing" } },
				{ "Description", new List<string> { "fishing is a fun hobby." } },
			};
			var transationList = new TransactionList(simulatedAPIData);

			Assert.IsTrue(transationList.Transactions.Count == 1);
		}

		[TestMethod]
		public void TransactionListAlternateConstructorWithInvalidColumns()
		{

			var hitException = false;
			var simulatedAPIData = new Dictionary<string, List<string>>()
			{
				{ " Amount", new List<string> { "100" } },
				{ "Date Posted ", new List<string> { "06/02/1986" } },
				{ " Transaction ID ", new List<string> { "2342342fdd" } },
				{ "Status", new List<string> { "COMPLETE" } },
				{ "Category", new List<string> { "Fishing" } },
				{ " Darth Jar Jar ", new List<string> { " The planet cooore." } },
			};
			try {
				var transationList = new TransactionList(simulatedAPIData);
			}
			catch (Exception ex) {
				hitException = true;
			}
			Assert.IsTrue(hitException);
		}

	}
}
