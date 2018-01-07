using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionAPI.Services.APIService
{
	public class TranscardAPIClient : IAPIClient
	{
		//todo: I would store this in a secure octopus variable normally
		public string HeaderAuthorizationKey { get; set; }
		public string Endpoint { get; set; }
	}
}