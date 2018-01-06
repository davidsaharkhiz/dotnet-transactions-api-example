using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TransactionAPI.Models
{

    public class TransactionList : ITransactionList
	{

		public int ID { get; set; }

		public List<Transaction> Transactions { get; set; } = new List<Transaction>();

		/// <summary>
		/// todo: let's move this to a service maybe?
		/// </summary>
		public void Normalize() {

		}

	}
}
