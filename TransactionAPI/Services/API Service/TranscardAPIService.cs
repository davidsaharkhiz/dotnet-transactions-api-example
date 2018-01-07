using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionAPI.Services.APIService
{
	public class TranscardAPIService
	{
		public TranscardAPIClient client;

		public TranscardAPIService() {
			client = new TranscardAPIClient(endpoint, authorizationKey);
		}

	}
}