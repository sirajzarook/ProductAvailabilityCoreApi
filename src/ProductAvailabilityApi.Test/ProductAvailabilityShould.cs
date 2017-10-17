using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProdcutAvailability.ApiModels;
using ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace ProductAvailabilityApi.Test
{
    public class ProductAvailabilityShould : BaseTestHost
	{
		[Fact]
		public void ReturnEansForRequestedVendor()
		{
			//Arrange


			HttpResponseMessage response = _client.GetAsync("api/v1/Product/NordsDropShip").Result;

			var responseString = response.Content.ReadAsStringAsync().Result;
			ApiOkResponse<object> apiResponse = JsonConvert.DeserializeObject<ApiOkResponse<object>>(responseString);
			var content = JsonConvert.DeserializeObject<Content<object>>(apiResponse.Content.Result.ToString());
			var result = JsonConvert.DeserializeObject<List<Product>>(content.Result.ToString());

			Assert.Equal((int)StatusCodes.Status200OK, (int)response.StatusCode);
			Assert.NotNull(result);

		}

		[Fact]
		public void ReturnEanRequested()
		{

			//Arrange

			HttpResponseMessage response = _client.GetAsync("api/v1/Product/NordsDropShip/0889059664247").Result;

			var responseString = response.Content.ReadAsStringAsync().Result;
			ApiOkResponse<object> apiResponse = JsonConvert.DeserializeObject<ApiOkResponse<object>>(responseString);
			var content = JsonConvert.DeserializeObject<Content<object>>(apiResponse.Content.Result.ToString());
			var result = JsonConvert.DeserializeObject<List<Product>>(content.Result.ToString());

			Assert.Equal((int)StatusCodes.Status200OK, (int)response.StatusCode);
			Assert.NotNull(result[0].EAN == "0889059664247");

			Assert.True(result.Count == 1);


		}

		[Fact]
		public void InsertValidCSVFormattedProductListIn()
		{

			//Arrange
			string productcsv = TestCSV.GetTestCSV1();
			var postContent = new  StringContent(productcsv, Encoding.UTF8, "text/plain");
			postContent.Headers.Remove("Content-Type");
			postContent.Headers.Add("Content-Type", "text/plain");

			HttpResponseMessage response = _client.PostAsync("api/v1/Product/", postContent).Result;

			var responseString = response.Content.ReadAsStringAsync().Result;
			ApiOkResponse<object> apiResponse = JsonConvert.DeserializeObject<ApiOkResponse<object>>(responseString);
			var content = JsonConvert.DeserializeObject<Content<object>>(apiResponse.Content.Result.ToString());

			Assert.Equal((int)StatusCodes.Status201Created, (int)response.StatusCode);
			Assert.Equal("Success", content.Result.ToString());


		}

		[Fact]
		public void ErrorOnInsertWithInvalidCSVFormattedProductListIn()
		{

			//Arrange
			string productcsv = TestCSV.GetTestCSV2_Wrong();  //input contains two error lines
			var postContent = new StringContent(productcsv, Encoding.UTF8, "text/plain");
			postContent.Headers.Remove("Content-Type");
			postContent.Headers.Add("Content-Type", "text/plain");

			HttpResponseMessage response = _client.PostAsync("api/v1/Product/", postContent).Result;

			var responseString = response.Content.ReadAsStringAsync().Result;
			ApiBadRequestResponse apiBadResponse = JsonConvert.DeserializeObject<ApiBadRequestResponse>(responseString);

			var result = apiBadResponse.Errors.ToList();


			Assert.Equal((int)StatusCodes.Status400BadRequest, (int)response.StatusCode);
			Assert.True(result.Count == 2);
			Assert.Equal("Check csv parser error list", apiBadResponse.Message);


		}

	}
}
