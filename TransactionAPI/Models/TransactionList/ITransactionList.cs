namespace TransactionAPI.Models
{
	/// <summary>
	/// Representation of a transaction
	/// </summary>
	public interface ITransactionList
	{
		int ID { get; set; }

		/// <summary>
		/// todo: let's move this to a service maybe?
		/// </summary>
		void Normalize();

	}

}
