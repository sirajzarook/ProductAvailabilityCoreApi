using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdcutAvailability.ApiModels
{
    public class ApiBadRequestResponse : ApiResponse
    {
		public IEnumerable<string> Errors { get; }

		[JsonConstructor]
		public ApiBadRequestResponse(int statusCode, string message, string[] errors)
			: base(statusCode, message)
		{

			Errors = errors;
		}
		public ApiBadRequestResponse(ModelStateDictionary modelState)
		: base(400, "Error occured. Check errors provided in the response")
		{
			if (modelState != null)
			{
				if (modelState.IsValid)
				{
					throw new ArgumentException("ModelState must be invalid", nameof(modelState));
				}

				Errors = modelState.SelectMany(x => x.Value.Errors)
					.Select(x => x.ErrorMessage).ToArray();
			}
		}
	}
}

