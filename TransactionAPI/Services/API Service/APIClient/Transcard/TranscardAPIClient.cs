using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using TransactionAPI.Services.API_Service.Response;
using System.Threading.Tasks;
using TransactionAPI.Models;

namespace TransactionAPI.Services.APIService
{
	public class TranscardAPIClient : IAPIClient
	{
		//todo: I would store this in a secure octopus variable normally
		public string HeaderAuthorizationKey { get; set; }
		public string Endpoint { get; set; }

		public IResponse Execute() {

			//todo: move me to controller
			Endpoint = "https://devproject.transcard.com/api/transactions/json/";
			HeaderAuthorizationKey = "TransCardDevTestKey";

			using (var client = new HttpClient())
			{

				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HeaderAuthorizationKey);
				var response = client.GetStringAsync(Endpoint);
				// todo; parse response
			}
			return new TransactionListResponse
			{
				TransactionList = new TransactionList()
			};

		}

	}
}