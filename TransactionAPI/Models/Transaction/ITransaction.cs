
using System;

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
		Guid ID { get; set; }
	}

}
