using Microsoft.AspNetCore.Mvc;
using MobyIpsumAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobyIpsumAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class MobyController : ControllerBase
    {
        // if no user input, give 'em 23 words
        private const int Length = 23;
        // GET: api/moby
        [HttpGet("moby")]
        public IEnumerable<string> GetMoby()
        {
            var payload = GeneratePayload("moby", Length);
            return payload;
        }
        // GET api/wealth
        [HttpGet("wealth")]
        public IEnumerable<string> GetWealth()
        {
            var payload = GeneratePayload("wealth", Length);
            return payload;
        }

        [HttpGet("copperfield")]
        public IEnumerable<string> GetCopperfield()
        {
            var payload = GeneratePayload("copperfield", Length);
            return payload;
        }

        [HttpGet("pride")]
        public IEnumerable<string> GetPride()
        {
            var payload = GeneratePayload("pride", Length);
            return payload;
        }

        [HttpGet("canterbury")]
        public IEnumerable<string> GetCanterbury()
        {
            var payload = GeneratePayload("canterbury", Length);
            return payload;
        }

        [HttpGet("wasteland")]
        public IEnumerable<string> GetWasteland()
        {
            var payload = GeneratePayload("wasteland", Length);
            return payload;
        }

        [HttpGet("metamorphosis")]
        public IEnumerable<string> GetMetamorphosis()
        {
            var payload = GeneratePayload("metamorphosis", Length);
            return payload;
        }

        [HttpGet("twocities")]
        public IEnumerable<string> GetTwoCities()
        {
            var payload = GeneratePayload("twocities", Length);
            return payload;
        }

        [HttpGet("paradise")]
        public IEnumerable<string> GetParadise()
        {
            var payload = GeneratePayload("paradise", Length);
            return payload;
        }

        private IEnumerable<string> GeneratePayload(string title, int length)
        {
            var data = new MobyDto(title);
            var payload = ContentProcessor.Process(length, data.Content);
            return new[] { data.Opening + " " + payload };
        }
    }
}

    
    //// POST api/<ValuesController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<ValuesController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/<ValuesController>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}
