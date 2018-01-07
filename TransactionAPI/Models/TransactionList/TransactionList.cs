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
		/// todo: let's move this to a service maybe?
		/// </summary>
		public void Normalize() {

		}

	}
}
