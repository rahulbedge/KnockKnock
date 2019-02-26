using KnockKnock.Interfaces;
using KnockKnock.Services;
using KnockKnock.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        [ServiceFilter(typeof(ValidateTriangleFilter))]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] int a, int b, int c)
        {
            return Ok(_triangleService.DetectTriangle(a, b, c));
        }
    }
}
