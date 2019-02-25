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
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([BindRequired, FromQuery(Name = "n")] long? number)
        {
            //TOD0: FIx and clean the error handling logic.
            if (string.IsNullOrEmpty(Request.Query["n"]) )
            {
                return NotFound(new { message = $"No HTTP resource was found that matches the request URI '{UriHelper.GetDisplayUrl(Request)}'." });
            }
            if ( number == null)
            {
                return BadRequest(new { message = "The request is invalid." });
            }

            if ( _numberService.Generate(number.Value, out long result) == true)
            {
                return Ok(result); 
            }
            return BadRequest("");
        }
    }
}
