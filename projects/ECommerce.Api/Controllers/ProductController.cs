using AutoMapper;
using ECommerce.Api.Models;
using ECommerce.ProductCatalog.Communication;
using ECommerce.ProductCatalog.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCatalogService _catalogService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _catalogService = ServiceProxy.Create<IProductCatalogService>(
                new Uri("fabric:/ECommerce/ECommerce.ProductCatalog"),
                new ServicePartitionKey(0));

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
        public async Task<ApiProduct> Get(int id)
        {
            return new ApiProduct
            {
                Id = Guid.NewGuid(),
                Description = "Test Product"
            };
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] ApiProduct product)
        {
            await _catalogService.AddProduct(_mapper.Map<Product>(product));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
