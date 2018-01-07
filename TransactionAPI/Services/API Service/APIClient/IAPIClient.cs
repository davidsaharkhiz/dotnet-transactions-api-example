using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionAPI.Services.API_Service.Response;
using System.Threading.Tasks;

namespace TransactionAPI.Services.APIService
{
	public interface IAPIClient
	{
		Uri Endpoint { get; set; }
	}
}
