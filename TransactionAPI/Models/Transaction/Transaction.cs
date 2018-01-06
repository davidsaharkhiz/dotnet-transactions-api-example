using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TransactionAPI.Models
{

    public class Transaction : ITransaction
    {

		public int ID { get; set; }
		public string Name { get; set; }

	}
}
