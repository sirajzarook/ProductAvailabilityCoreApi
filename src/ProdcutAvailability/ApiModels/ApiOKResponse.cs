using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdcutAvailability.ApiModels
{
	public class ApiOkResponse<T> : ApiResponse
	{
		public Head Head { get; set; }
		public Content<T> Content { get; }

		public ApiOkResponse(T content, Head head, int status_code = 200)
			: base(status_code, status_code == 201 ? "Insert was success" : content != null ? "Read data populated in response content/result" : "No result to be returned")
		{
			this.Content = new Content<T>(content);
			this.Head = head;
			
		}
	}
}
