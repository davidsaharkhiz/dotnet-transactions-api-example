using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TransactionAPI.Models
{

    public class TransactionList : ITransactionList
	{

		public int ID { get; set; }

		/// <summary>
		/// todo: let's move this to a service maybe?
		/// </summary>
		public void Normalize() {
		}

	}
}
