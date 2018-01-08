using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TransactionAPI.Services.APIService;

namespace TransactionAPI.Tests.Services.APIClient.Transcard
{
	
	[TestClass]
	public class TranscardAPIClientTest
	{

		private Mock<TranscardAPIClient> mockClient;

		[TestInitialize]
		public void SetUp() {
			mockClient = new Mock<TranscardAPIClient>();
			mockClient.Setup(x => x.GetResponseDictionary()).Returns(new Dictionary<string, List<string>>()
			{
				{ "Amount", new List<string> { "100", "100"  }},
				{ "Date Posted", new List<string> { "06/02/1986", "06/02/1986" } },
				{ "Transaction ID", new List<string> { "2342342fdd", "2342342fdd" } },
				{ "Status", new List<string> { "SETTLED", "SETTLED" } },
				{ "Category", new List<string> { "Fishing", "Skiing" } },
				{ "Description", new List<string> { "fishing is a fun hobby.", "Skiing is a fun hobby." } },
			});
		}

		[TestMethod]
		public void APIServiceInstantiation()
		{
			var service = new TranscardAPIService();
		}

		[TestMethod]
		public void APIServiceGetTransactionList()
		{
			var transactionList = mockClient.Object.GetTransactionList();
			var firstTransaction = transactionList.Transactions.First();
			Assert.AreEqual(firstTransaction.Amount, 100);
			Assert.AreEqual(firstTransaction.DatePosted.Day, 2);
			Assert.AreEqual(firstTransaction.ID, "2342342fdd");
			Assert.AreEqual(firstTransaction.StatusForUI, "SETTLED");
			Assert.AreEqual(firstTransaction.Category, "Fishing");
		}

		[TestMethod]
		public void APIServiceGetTransactionListNormalizesData()
		{
			var transactionList = mockClient.Object.GetTransactionList();
			Assert.IsTrue(transactionList.Transactions.Count == 1);
		}

	}
}
