using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdcutAvailability.ApiModels
{
	public class ApiResponse
	{
		//public Head Head { get; set; }

		//public Content<T> Content { get; set; }

		public int StatusCode { get; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; }

		public ApiResponse(int statusCode, string message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);

		}

		private static string GetDefaultMessageForStatusCode(int statusCode)
		{
			// keep adding all the known error status codes
			switch (statusCode)
			{

				case 404:
					return "Resource not found";
				case 500:
					return "An unhandled error occurred";
				default:
					return null;
			}
		}
	}
}
