using System.Collections.Generic;
namespace TransactionAPI.Models
{
	/// <summary>
	/// Representation of a transaction
	/// </summary>
	public interface ITransactionList
	{
		int ID { get; set; }

		List<Transaction> Transactions { get; set; }

		/// <summary>
		/// todo: let's move this to a service maybe?
		/// </summary>
		void Normalize();

	}

}
