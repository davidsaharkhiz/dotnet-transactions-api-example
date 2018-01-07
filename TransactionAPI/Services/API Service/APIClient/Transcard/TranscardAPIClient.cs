using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using TransactionAPI.Services.API_Service.Response;
using System.Threading.Tasks;
using TransactionAPI.Models;
using System.Configuration;

namespace TransactionAPI.Services.APIService
{
	public class TranscardAPIClient : IAPIClient
	{
		//todo: I would store this in a secure octopus variable normally
		public string HeaderAuthorizationKey { get; set; }
		public Uri Endpoint { get; set; }


		/// <summary>
		/// Default constructor, pulls values from config
		/// </summary>
		public TranscardAPIClient() {

			var authorizationKey = ConfigurationManager.AppSettings["TranscardAuthorizationKey"];
			var transcardUri = ConfigurationManager.AppSettings["TransCardApiUri"];

			if(string.IsNullOrEmpty(authorizationKey)|| string.IsNullOrEmpty(transcardUri)) {
				throw new ConfigurationErrorsException($"{nameof(transcardUri)} or {nameof(authorizationKey)} could not be retrieved. Client instantiation failed.");
			}

			Endpoint = new Uri(transcardUri);
			HeaderAuthorizationKey = "TransCardDevTestKey";
		}

		/// <summary>
		/// On the fly creation
		/// </summary>
		/// <param name="headerAuthorizationKey">The key to be used in the request</param>
		/// <param name="endpoint">uri to hit. Failure to parse will result in a UriFormatException</param>
		public TranscardAPIClient(string headerAuthorizationKey, string endpoint) {
			HeaderAuthorizationKey = headerAuthorizationKey;
			Endpoint = new Uri(endpoint);
		}

		public IResponse Execute() {

		

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