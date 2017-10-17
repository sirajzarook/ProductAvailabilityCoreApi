using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ProdcutAvailability;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ProductAvailabilityApi.Test
{
	public class BaseTestHost
	{
		protected readonly TestServer _server;
		protected readonly HttpClient _client;

		public BaseTestHost()
		{
			// Arrange

			_server = new TestServer(new WebHostBuilder()
				.UseStartup<TestStartup>());
			_client = _server.CreateClient();



		}

	}
}
