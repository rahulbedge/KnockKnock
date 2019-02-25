using KnockKnock.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KnockKnock.Controllers
{
    [Route("api/Fibonacci", Name = "Fibonacci")]
    //    [Produces("application/json")]

    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly INumberSeries _numberService;
        public FibonacciController(INumberSeries numberSeries)
        {
            _numberService = numberSeries; 
        }


        // GET: api/Fibonacci
        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([BindRequired, FromQuery(Name = "n")] string number  )
        {
            // TODO: Simplify this error handling mechanism. 
            if (!ModelState.IsValid)
            {
                return NotFound(new {
                    //TODO: Implement Url path
                    //message = $"No HTTP resource was found that matches the request URI '{UriHelper.GetDisplayUrl(Request)}'"
                    message = $"No HTTP resource was found that matches the request URI '<Implement path>'"
                }); 
            }
            else
            {
                if (long.TryParse(number, out long num))
                {
                    if (num < 93) return Ok(_numberService.Generate(num)); 
                    else return BadRequest(string.Empty);
                }
            }
            return BadRequest(new
            {
                message = "The request is invalid."
            });
        }
    }
}
