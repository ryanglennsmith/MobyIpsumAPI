using Microsoft.AspNetCore.Mvc;
using MobyIpsumAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobyIpsumAPI.Controllers
{
    [Route("api/moby")]
    [ApiController]
    public class MobyController : ControllerBase
    {
        // GET: api/moby
        [HttpGet]
        public IEnumerable<string> GetMain()
        {
            var payload = new MobyDto("moby");
            return new string[] { payload.Opening + payload.Content };
        }
        // GET api/moby/other
        [HttpGet("other")]
        public IEnumerable<string> GetOther()
        {
            return new string[] { "other", "ipsum" };
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
