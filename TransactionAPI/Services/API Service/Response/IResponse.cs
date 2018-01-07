using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionAPI.Services.API_Service.Response
{
	public interface IResponse
	{
		bool Success { get; set; }
	}
}