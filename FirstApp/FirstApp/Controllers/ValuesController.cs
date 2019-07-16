using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly FirstApp.Models.Environment _environment;
        private readonly IStringLocalizer<ValuesController> _localise;

        public ValuesController(IOptions<FirstApp.Models.Environment> options, IStringLocalizer<ValuesController> localise)
        {
            _environment = options.Value;
            _localise = localise;
        }

        /// <summary>
        /// Get method for testing purpose
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> Get()
        {
            return $"Hello {_environment.Description} {_localise["Hello"]}";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
