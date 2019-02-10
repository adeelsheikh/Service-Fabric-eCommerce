using AutoMapper;
using ECommerce.Api.Models;
using ECommerce.ProductCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCatalogService _catalogService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _catalogService = ProductCatalogServiceResolver.Resolve();

            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ApiProduct>> Get()
        {
            return (await _catalogService.GetAllProducts()).Select(_mapper.Map<ApiProduct>);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ApiProduct> Get(Guid id)
        {
            return _mapper.Map<ApiProduct>(await _catalogService.GetProduct(id));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] ApiProduct product)
        {
            var dbProduct = _mapper.Map<Product>(product);
            dbProduct.Availability = 50;

            await _catalogService.AddProduct(dbProduct);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _catalogService.DeleteProduct(id);
        }
    }
}
