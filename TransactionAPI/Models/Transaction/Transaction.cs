﻿using System;
using TransactionAPI.Helpers;

namespace TransactionAPI.Models
{

    public class Transaction : ITransaction
    {

		public string ID { get; set; }
		public DateTime DatePosted { get; set; }
		public string Description { get; set; }
		public decimal Amount { get; set; }
		public string Category { get; set; }
		public TransactionStatus Status { get; set; }
		public string StatusForUI { get; set; }


		public Transaction() {

		}

		/// <summary>
		/// Create a transaction with the supplied values from the API
		/// </summary>
		public Transaction(string amount, string datePosted, string id, string description, string category, string status) {
			// Developer's notes: Hey, normally I would tryparse this stuff since in a production environment we'd rather not grind the user experience to a halt,
			//but for the purposes of the demo I'm not accounting for this kind of user experience stuff, and I'm letting the exception bubble up
			Amount = ParseHelper.CoerceSignedStringToDecimal(amount);
			DatePosted = DateTime.Parse(datePosted);
			ID = id;
			Description = Description;
			Category = category;
			Status = TransactionStatus.Unknown; // todo: flesh out a mapper for this later, not really useful for the purposes of the demo
			StatusForUI = status;
		}

	}
}
