namespace TransactionAPI.Models
{

	public enum TransactionStatus
	{
		Settled,
		Unknown
	}

	/// <summary>
	/// Representation of a transaction
	/// </summary>
	public interface ITransaction
	{
		string ID { get; set; }
	}

}
