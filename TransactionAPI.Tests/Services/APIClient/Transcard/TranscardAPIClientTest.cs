using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionAPI.Services.APIService;

namespace TransactionAPI.Tests.Services.APIClient.Transcard
{
	
	[TestClass]
	public class TranscardAPIClientTest
	{
		[TestMethod]
		public void APIServiceInstantiation()
		{
			var service = new TranscardAPIService();
		}
	}
}
