using Microsoft.AspNetCore.Mvc;
using MobyIpsumAPI.Data;
using System.Net.Mime;

namespace MobyIpsumAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api")]
    [ApiController]
    public class MobyController : ControllerBase
    {
        // if no user input, give 'em 23 words
        private const int Length = 23;
        [HttpGet("{endpoint?}")]
        public IActionResult GetEndpoint(string endpoint)
        {
            var payload = GeneratePayload(endpoint, Length);
            if (payload == null)
                return NotFound("bad title");
            return Ok(payload);
        }
        [HttpGet("{endpoint?}/{length}")]
        public IActionResult GetEndpointWithSpecificLength(string endpoint, int length)
        {
            if (length > 999)
                return BadRequest("request too many, max 999");
            var payload = GeneratePayload(endpoint, length);
            if (payload == null)
                return NotFound();
            return Ok(payload);
        }
        private static Payload? GeneratePayload(string title, int length)
        {
            var data = new MobyDto(title);

            if (data.Title == null)
            {
                return null;
            }
            else
            {
                var processed = ContentProcessor.Process(length, data.Content);
                var payload = new Payload(data.Title, data.Opening, processed);
                return payload;
            }

        }
        public class Payload
        {
            public string? Title { get; set; }
            public string? Content { get; set; }
            public Payload(string? title, string? opening, string? processedText)
            {
                Title = title;
                Content = opening + " " + processedText + ".";
            }
        }
    }
}
