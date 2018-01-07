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
		public string EndpointSuffix { get; set; } = string.Empty;

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
			HeaderAuthorizationKey = authorizationKey;

			

		}
		

		/// <summary>
		/// Returns a transactionList from the API
		/// </summary>
		public TransactionList GetTransactionList() {

			var list = new TransactionList();
			EndpointSuffix = "transactions";
			var result = Execute();
			//todo: actually parse response
			return list;
		}

		/// <summary>
		/// get the raw response from the API
		/// </summary>
		private string Execute() {

			Uri finalUri = Endpoint;
			var finalUriString = $"{Endpoint.ToString()}{EndpointSuffix}/";
			if (!String.IsNullOrEmpty(EndpointSuffix)) {
				try
				{
					finalUri = new Uri(finalUriString);
				}
				catch (UriFormatException ex) {
					throw new UriFormatException($"The Uri {finalUriString} for this client is invalid", ex);
				}

			}

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HeaderAuthorizationKey);
				var response = client.GetStringAsync(finalUri).Result;
				return response;

			}
			

		}


		

	}
}