using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionAPI.Controllers;
using System.Web.Mvc;

namespace TransactionAPI.Tests.Controllers
{
	[TestClass]
	public class TransactionControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			var controller = new TransactionController();

			// Act
			var result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void List()
		{
			// Arrange
			var controller = new TransactionController();

			// Act
			var result = controller.List() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

	}
}
