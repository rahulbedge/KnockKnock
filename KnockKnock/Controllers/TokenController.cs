using KnockKnock.Interfaces;
using KnockKnock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Token")]
    [ApiController]
    [Produces("application/json")]
    public class TokenController : ControllerBase
    {
        /// <summary>
        /// Controller action method to return the readify token
        /// </summary>
        /// <returns>Redify token</returns>
        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            string token = "72e0b481-72b8-4fc9-bb7f-a259b4f92ae7"; 
            return Ok(token);
        }
    }
}
