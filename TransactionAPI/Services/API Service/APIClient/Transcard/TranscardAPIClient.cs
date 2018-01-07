using System;
using System.Collections.Generic;
using System.Net.Http;
using TransactionAPI.Models;
using System.Configuration;
using TransactionAPI.Helpers;
using System.Linq;

namespace TransactionAPI.Services.APIService
{
	public class TranscardAPIClient : IAPIClient
	{
		//todo: I would store this in a secure octopus variable normally
		public string HeaderAuthorizationKey { get; set; }
		public Uri Endpoint { get; set; }

		/// <summary>
		/// Additional URL suffix after the base endpoint
		/// </summary>
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

			
			EndpointSuffix = "transactions";
			
			//create a typed object from our response dictionary
			var list = new TransactionList(GetResponseDictionary());

			// normalize
			list.Transactions = list.Transactions.Distinct().ToList();

			return list;
		}

		/// <summary>
		/// get the raw response from the API
		/// </summary>
		private Dictionary<string, List<string>> GetResponseDictionary() {

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
				return ParseHelper.BuildDictionaryFromTabbedAPIResponse(response);
			}
			

		}

	}
}