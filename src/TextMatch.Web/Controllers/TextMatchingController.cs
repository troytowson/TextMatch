using TextMatch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TextMatch.Controllers
{
    /// <summary>
    /// Represents a controller text matching.
    /// </summary>
    public class TextMatchingController : ApiController
    {
        private ITextMatchingService _textMatchingService;
        
        /// <summary>
        /// Initialises a new instance of the TextMatchingController class.
        /// </summary>
        public TextMatchingController(ITextMatchingService textMatchingService)
        {
            _textMatchingService = textMatchingService;
        }
        
        /// <summary>
        /// Get entry point for text matching.
        /// </summary>
        [Route("api/v1/textmatching")]
        [HttpGet]
        public IHttpActionResult Get(string text="", string subtext="")
        {
            return Ok(_textMatchingService.Match(text, subtext));
        }
    }
}
