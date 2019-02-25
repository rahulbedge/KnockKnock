using KnockKnock.Interfaces;
using KnockKnock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Controllers
{
    [Route("api/ReverseWords")]
    [ApiController]
    [Produces("application/json")]
    public class TextController : ControllerBase
    {
        private readonly ITextService _textService;
        public TextController(ITextService textSeries)
        {
            _textService = textSeries ; 
        }

        // GET: api/Fibonacci
        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery(Name = "sentence")] string sentence)
        {
            return Ok(_textService.ReverseWords(sentence));
        }
    }
}
