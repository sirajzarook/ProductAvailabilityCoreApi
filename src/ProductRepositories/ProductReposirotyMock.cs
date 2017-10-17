using System;
using System.Collections.Generic;
using System.Text;
using ProductModels;
using System.Linq;

namespace ProductRepositories
{
	public class ProductReposirotyMock : IProductRepository
	{

		List<Product> _products;

		public ProductReposirotyMock()
		{
			_products = new List<Product>() {
				new Product { EAN = "0889059664247", Vendor = "NordsDropShip", StateDate = Convert.ToDateTime("2017/10/01"), EndDate = Convert.ToDateTime("2017/01/01") },
				new Product { EAN = "0889059664248", Vendor = "NordsDropShip", StateDate = Convert.ToDateTime("2017/10/01"), EndDate = Convert.ToDateTime("2017/01/01") }
				};
		}
		public void Create(Product product)
		{
			_products.Add(product);
		}

		public IEnumerable<Product> GetProduct()
		{
			//var availableStock = _products.Where(x => x.Vendor.ToLower() == vendor.ToLower()).ToList();
			var availableProdcut = _products.AsEnumerable();


			return availableProdcut;
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

	}
}
