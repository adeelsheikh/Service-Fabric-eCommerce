using ECommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ApiProduct>> Get()
        {
            return new ApiProduct[]
            {
                new ApiProduct
                {
                    Id = Guid.NewGuid(),
                    Description = "Test Product"
                }
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ApiProduct> Get(int id)
        {
            return new ApiProduct
            {
                Id = Guid.NewGuid(),
                Description = "Test Product"
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
