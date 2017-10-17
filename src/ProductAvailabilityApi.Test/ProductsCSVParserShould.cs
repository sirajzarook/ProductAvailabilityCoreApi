using ProdcutAvailability.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductAvailabilityApi.Test
{
    public class ProductsCSVParserShould
    {

		[Fact]
		public void ParseCSVFile()
		{
			var exampleCSV = TestCSV.GetTestCSV1();
			var parser = new ProductsCSVParser();
			parser.TryParse(exampleCSV);
			var result = parser.Result;
			Assert.NotNull(result);

			Assert.Equal("0889059664247", result[0].EAN);
			Assert.Equal("NordsDropShip", result[0].Vendor);

			Assert.Equal("0889059664248", result[1].EAN);
			Assert.Equal("NordsDropShip", result[1].Vendor);

		}



		[Fact]
		public void ReturnErrorsWhenWorngData()
		{
			var exampleCSV = TestCSV.GetTestCSV2_Wrong();
			var parser = new ProductsCSVParser();
			parser.TryParse(exampleCSV);
			var result = parser.Result;
			Assert.Null(result);
			Assert.True(parser.HasErrors);
			Assert.NotEmpty(parser.Errors);

		}

		[Fact]
		public void ReturnErrorsWhenWorngDate()
		{
			var exampleCSV = TestCSV.GetTestCSV_WrongDate();
			var parser = new ProductsCSVParser();
			parser.TryParse(exampleCSV);
			var result = parser.Result;
			Assert.Null(result);
			Assert.True(parser.HasErrors);
			Assert.NotEmpty(parser.Errors);

		}
	}
}
