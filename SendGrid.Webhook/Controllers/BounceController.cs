using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SendGrid.Webhook.Models;

namespace SendGrid.Webhook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BounceController : ControllerBase
    {
        private static ConcurrentBag<Processed> processed = new ConcurrentBag<Processed>();

        // POST api/values
        [HttpPost]
        public void Post([FromBody] object value)
        {
            processed.Add(new Models.Processed() { OriginalJson = JsonConvert.SerializeObject(value) });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(JsonConvert.SerializeObject(processed));
        }
    }
}
