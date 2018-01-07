using System;
using TransactionAPI.Models;
namespace TransactionAPI.Services.API_Service.Response {

	public class TransactionListResponse : IResponse
	{
		public bool Success { get; set; }
		public TransactionList TransactionList { get; set; }
	}

}


