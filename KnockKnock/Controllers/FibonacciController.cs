using KnockKnock.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq; 

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


        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <param name="n">The index (n) of the fibonacci sequence</param>
        /// <returns>long</returns>
        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([BindRequired, FromQuery(Name = "n")] long number = long.MinValue)
        {
            string test = Request.QueryString.Value; 
            // TODO: Simplify this error handling mechanism with custom validator. 
            if (!ModelState.IsValid )
            {
                if (ModelState.Values.Select(z => z.AttemptedValue == null).Count() > 0)
                {
                    return BadRequest( new {message = "The request is invalid."});
                }
                else
                {
                    return BadRequest(new { message = "No HTTP resource was found that matches the request URI 'https://knockknock.readify.net/api/Fibonacci?na=90'." });
                }
            }

            if (number < 93) return Ok(_numberService.Generate(number)); 
            else return BadRequest(string.Empty);
        }
    }
}
