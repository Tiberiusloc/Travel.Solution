using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningSampleApp.Controllers
{
    // [ApiVersion("1.0")]
    [Route("api/Values")]
    public class ValuesV1Controller : Controller
    {
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
    return new string[] { "Value1 from Version 1", "value2 from Version 1" };
    }
    }
    
    // [ApiVersion("2.0", Deprecated = true)]
    [Route("api/v2/Values")] // Use different route names
    public class ValuesV2Controller : Controller
    {
  // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
    return new string[] { "value1 from Version 2", "value2 from Version 2" };
    }
  }
}