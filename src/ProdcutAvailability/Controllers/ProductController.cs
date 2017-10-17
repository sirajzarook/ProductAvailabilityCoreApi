using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductRepositories;
using ProductModels;
using ProdcutAvailability.ApiModels;
using ProdcutAvailability.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdcutAvailability.Controllers
{

	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class ProductController : Controller
    {
		private readonly IProductRepository _prodcutRepository;
		public ProductController(IProductRepository productRepository)
		{
			_prodcutRepository = productRepository;
		}


		/// <summary>
		/// Get Products
		/// </summary>
		/// <param name="vendor"></param>
		/// <param name="ean"></param>
		/// <returns></returns>
		// GET: api/v1/prodcut?vendor=yourvalues&ean=yourvalue
		//[HttpGet]
		////[Route("{vendor}/{ean?}")]
		//[Route("{vendor}")]
		//public List<Product> Get(string vendor, string ean = null)
		//{
		//	if (ean == null)
		//		return _prodcutRepository.GetProduct().Where(t => t.Vendor == vendor).ToList();

		//	return _prodcutRepository.GetProduct().Where(t => t.Vendor == vendor && t.EAN == ean).ToList();
		//}


		/// <summary>
		///	Get Products EANs	
		/// </summary>
		/// <param name="vendor"></param>
		/// <param name="ean"></param>
		/// <returns></returns>
		//  api/v1/Product/NordsDropShip/ean
		[HttpGet]
		[Route("{vendor}/{ean?}")]
		//[Route("{vendor}")]
		public IActionResult GetProductList(string vendor, string ean = null)
		{
			List<Product> products;
			if (ean == null || ean == "{ean}")  // TODO this is bug only in swagger documentation does not work for optional params core 2.0
				products = _prodcutRepository.GetProduct().Where(t => t.Vendor == vendor).ToList();
			else
				products = _prodcutRepository.GetProduct().Where(t => t.Vendor == vendor && t.EAN == ean).ToList();

			//TODO For now we return the result in single page
			Head head = new Head()
			{
				page_num = 1,
				page_count = 1,
				page_size = products.Count

			};

			var content = new Content<object>(products);

			//ApiModel model = new ApiModel<Head,Content<C>()>(head,products)
			//var model = new ApiModel<Head, Content<Content<object>>(head, content);

			//return Ok(new ApiOkResponse<object>(JsonConvert.SerializeObject(products), JsonConvert.SerializeObject(head)));
			//return Ok(new ApiOkResponse(JsonConvert.SerializeObject(products), JsonConvert.SerializeObject(head)));
			return Ok(new ApiOkResponse<object>(products,head));

		}

		/// <summary>
		/// Insert product EAN list in csv format
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		/// <response code="201">Returns message confirmting the order created</response>
		/// <response code="400">If the item is null</response>
		[HttpPost]
		[Consumes("text/plain")]
		[ProducesResponseType(typeof(string), 201)]
		[ProducesResponseType(typeof(string), 400)]
		public IActionResult Post([FromBody]string data)
		{
			//TODO: Add models validation
			var parser = new ProductsCSVParser();
			if (parser.TryParse(data))
			{
				foreach (var p in parser.Products)
				{
					_prodcutRepository.Create(p);
				}
				return Created("", new ApiOkResponse<object>("Inset was success", null, 201));
				//return Ok(new ApiOkResponse<object>("Success", null));

			}
			else
			{
				//TODO get errors from parser
				if(parser.HasErrors)
					return BadRequest(new ApiBadRequestResponse(StatusCodes.Status400BadRequest, "Check csv parser error list",  parser.Errors.ToArray()));
			}
			return BadRequest(new ApiBadRequestResponse(StatusCodes.Status500InternalServerError, "Unxpected error check the csv input", null)); //TODO Unhandled error

		}

	}
}
