using CsvHelper;
using CsvHelper.Configuration;
using ProductModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProdcutAvailability.Helpers
{
    public class ProductsCSVParser
    {

		private List<Product> products;
		private List<string> errors;

		public List<Product> Products
		{
			get
			{
				return products;
			}
		}

		public ProductsCSVParser()
		{
			this.errors = new List<string>();
		}

		public bool TryParse(string csv)
		{
			this.products = new List<Product>();
			var readerConfig = new Configuration()
			{
				HasHeaderRecord = false,
			};
			using (var strem = csv.ToStream())
			using (var reader = new CsvReader(new StreamReader(strem), readerConfig))
			{
				reader.Configuration.RegisterClassMap<ProdcutMap>();
				while (reader.Read())
				{
					try
					{
						var item = reader.GetRecord<Product>();
						this.products.Add(item);
					}
					catch (Exception ex)
					{
						var row = reader.Parser.Context.RawRecord;
						var errorMessage = $"{ex.Message} in row: {row}";
						errors.Add(errorMessage);
					}
				}
			}

			return !HasErrors;
		}

		public List<Product> Result
		{
			get
			{
				return (products == null || errors.Any()) ? null : products;
			}
		}

		public List<string> Errors
		{
			get
			{
				return errors;
			}
		}

		public bool HasErrors
		{
			get
			{
				return errors.Any();
			}
		}
	}
}
