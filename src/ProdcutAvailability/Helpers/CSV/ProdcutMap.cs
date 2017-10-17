using CsvHelper.Configuration;
using ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdcutAvailability.Helpers
{
	public sealed class ProdcutMap : ClassMap<Product>
	{
		public ProdcutMap()
		{
			Map(r => r.EAN).Index(0);
			Map(r => r.Vendor).Index(1);
			Map(r => r.StateDate).Index(2);
			Map(r => r.EndDate).Index(3);
		}
	}
}
