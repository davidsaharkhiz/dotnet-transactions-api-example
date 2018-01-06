
namespace TransactionAPI.Models
{
	/// <summary>
	/// Representation of a transaction
	/// </summary>
	public interface ITransaction
	{
		int ID { get; set; }
		string Name { get; set; }

	}

}
