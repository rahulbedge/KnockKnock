using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KnockKnock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Controllers
{
    [Route("api/Fibonacci")]
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
        public IActionResult Get([FromQuery(Name = "n")] long number)
        {
            // check to catch the overflow of the long.
            //TODO: Check if we can use query filter 
            if ( number >= 93)
            {
                // TODO: no content
                return BadRequest();
            }
            return Ok(_numberService.Generate(number));
        }
    }
}
