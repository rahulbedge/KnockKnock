using KnockKnock.Interfaces;
using KnockKnock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Controllers
{
    [Route("api/Token")]
    [ApiController]
    [Produces("application/json")]
    public class TokenController : ControllerBase
    {
        public TokenController()
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            //string token = "72e0b481-72b8-4fc9-bb7f-a259b4f92ae7"; 
            string token = "72e0b481-72b8-4fc9-bbbb-a259b4f92abb"; 
            return Ok(token);
        }
    }
}
