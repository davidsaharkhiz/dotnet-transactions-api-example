using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TransactionAPI.Helpers;

namespace TransactionAPI.Models
{

    public class Transaction : ITransaction
    {

		public Guid ID { get; set; }
		public DateTime DatePosted { get; set; }
		public string Description { get; set; }
		public decimal Amount { get; set; }
		public string Category { get; set; }
		public TransactionStatus Status { get; set; }
		public string StatusForUI { get; set; }

		/// <summary>
		/// Create a transaction with the supplied values from the API
		/// </summary>
		public Transaction(string amount, string datePosted) {
			// Developer's notes: Hey, normally I would tryparse this stuff since in a production environment we'd rather not grind the user experience to a halt,
			//but for the purposes of the demo I'm not accounting for this kind of user experience stuff.
			Amount = ParseHelper.CoerceSignedStringToDecimal(amount);
			DatePosted = DateTime.Parse(datePosted);
		}

	}
}
