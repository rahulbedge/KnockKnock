using KnockKnock.Interfaces;
using KnockKnock.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq; 

namespace KnockKnock.Controllers
{
    [Route("api/Fibonacci", Name = "Fibonacci")]
    [ApiController]
    [Produces("application/json")]
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
        [ServiceFilter(typeof(ValidateFibonacciFilter))]
        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([BindRequired, FromQuery(Name = "n")] long number)
        {
            if ( _numberService.Generate(number, out long result) == true)
            {
                return Ok(result); 
            }
            return BadRequest("");
        }
    }
}
