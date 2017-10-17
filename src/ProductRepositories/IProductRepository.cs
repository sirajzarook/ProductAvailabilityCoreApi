using ProductModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductRepositories
{
    public interface IProductRepository
    {

		//Task<IEnumerable<Stock>> GetStockByVendorAsync(string vendor);
		IEnumerable<Product> GetProduct();
		//goes here, any additional implementation outside the generic repository

		void Create(Product product);
		
		void Save();
	}
}
