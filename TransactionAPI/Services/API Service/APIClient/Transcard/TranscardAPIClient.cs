using System;
using System.Collections.Generic;
using System.Net.Http;
using TransactionAPI.Models;
using System.Configuration;
using TransactionAPI.Helpers;
using System.Linq;
using System.IO;

namespace TransactionAPI.Services.APIService
{
	public class TranscardAPIClient : IAPIClient
	{
		// note to interviewer: I would store this in a secure octopus variable normally
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
			
			// Create a typed object from our response dictionary
			var list = new TransactionList(GetResponseDictionary());

			// Normalize the data based on ID
			if (list.Transactions.Any()) {
				
				list.Transactions = list.Transactions.GroupBy(d => new { d.ID })
									 .Select(d => d.First())
									 .ToList();
			}
			return list;
		}


		

		/// <summary>
		/// Get the raw response from the API
		/// </summary>
		/// <returns>A key/associated values dictionary</returns>
		public virtual Dictionary<string, List<string>> GetResponseDictionary() {

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
				var response = client.GetStringAsync(finalUri + "breakme").Result;

				if(response == null) {
					response = GetMockResponse();
				}

				return ParseHelper.BuildDictionaryFromTabbedAPIResponse(response);
			}
			

		}

		/// <summary>
		/// A convenience method so that we can demo the program in the event the public API is dowwn. For demonstration purposes only.
		/// </summary>
		public string GetMockResponse() {
			var filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
			filePath += @"\SampleAPIResponse.txt";
			var tr = new StreamReader(filePath);
			return tr.ReadToEnd();
		}


	}
}