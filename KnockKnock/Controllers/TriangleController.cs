using KnockKnock.Interfaces;
using KnockKnock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Controllers
{
    [Route("api/TriangleType")]
    [ApiController]
    [Produces("application/json")]
    public class TriangleController : ControllerBase
    {
        private readonly ITriangleService _triangleService;
        public TriangleController(ITriangleService triangleService)
        {
            _triangleService = triangleService;
        }

        // GET: api/TriangleType
        /// <summary>
        /// Detects triangle type from lengths of sides
        /// </summary>
        /// <param name="a">Length of side a</param>
        /// <param name="b">Length of side b</param>
        /// <param name="c">Length of side c</param>
        /// <returns>Triangle type</returns>
        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] int? a, int? b, int? c)
        {
            if (string.IsNullOrEmpty(Request.Query["a"]) ||
                string.IsNullOrEmpty(Request.Query["b"]) ||
                string.IsNullOrEmpty(Request.Query["c"]))
            {
                return NotFound(new { message = $"No HTTP resource was found that matches the request URI '{UriHelper.GetDisplayUrl(Request)}'." });
            }
            if (a.HasValue == false || b.HasValue == false || c.HasValue == false)
            {
                return BadRequest(new { message = "The request is invalid." });
            }

            return Ok(_triangleService.DetectTriangle(a.Value, b.Value, c.Value).ToString());
        }
    }
}
