using KnockKnock.Interfaces;
using KnockKnock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Controllers
{
    [Route("api/ReverseWords")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ITextService _textService;
        public TextController(ITextService textSeries)
        {
            _textService = textSeries ; 
        }
    }
}
