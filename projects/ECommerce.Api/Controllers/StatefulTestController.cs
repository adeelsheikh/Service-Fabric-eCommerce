using Microsoft.AspNetCore.Mvc;
using StatefulTestService.Models;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatefulTestController : ControllerBase
    {
        public string Get()
        {
            return TestServiceResolver.Resolve().Test().Result;
        }
    }
}
