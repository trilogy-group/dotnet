using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Structurizr.Reflection.Tests.Controllers
{
    [Route("api/[controller]")]
    public class StubController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
