using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductModels
{
    public class Product
	{
		[Key, Column(Order = 0)]
		public string EAN { get; set; }
		[Key, Column(Order = 1)]
		public string Vendor { get; set; }
		public DateTime StateDate { get; set; }
		public DateTime EndDate { get; set; }
	}

	
}
