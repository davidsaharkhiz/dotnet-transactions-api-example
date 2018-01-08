using System.Collections.Generic;
namespace TransactionAPI.Models
{
	public interface ITransactionList
	{
		List<Transaction> Transactions { get; set; }
	}

}
