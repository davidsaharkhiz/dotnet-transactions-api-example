using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

	}
}
