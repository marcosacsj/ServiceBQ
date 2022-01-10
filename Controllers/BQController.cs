using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BQController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [Route("")]
        public IActionResult Get( )
        {

            return Ok(null);
        }
    }
}