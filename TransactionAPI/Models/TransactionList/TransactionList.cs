using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TransactionAPI.Models
{

	/// <summary>
	/// A class for managing a list of transactions from a specific API
	/// </summary>
    public class TransactionList : ITransactionList
	{

		public int ID { get; set; }

		public List<Transaction> Transactions { get; set; } = new List<Transaction>();

		public TransactionList() {

		}

		/// <summary>
		/// coerces a response from the to a typed transactionlist. I know for the purposes of this demo it might be overkill but I can't stand passing around strings, mutation becomes a nightmare without strong typing.
		/// </summary>
		/// <param name="responseToCoerce">Response from the API</param>
		public TransactionList(Dictionary<string, List<string>> responseToCoerce) {
			for(var i = 0; i < responseToCoerce.Count(); i++) {
				var amount = responseToCoerce["Amount"][i];
				var datePosted = responseToCoerce["Date Posted"][i];

				//so this has an amount, etc, transaction should do it
				var transaction = new Transaction(amount, datePosted);
				Transactions.Add(transaction);
			}
		}
		


	}
}
