using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdcutAvailability.ApiModels
{
	public class Content<T>
	{
		public Content()
		{ }

		public Content(T result)
		{
			this.Result = result;
		}
		public T Result { get; set; }

	}
}
