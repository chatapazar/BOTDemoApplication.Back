using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BOTDemoApplication.Back.Model;
using Microsoft.AspNetCore.Mvc;

namespace BOTDemoApplication.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return StatusCode((int)HttpStatusCode.OK, "Hello from back");
        }

        // GET api/values/information
        [HttpGet("information")]
        public ActionResult<string> GenerateInformation()
        {
            Console.WriteLine("GenerateInformation got invoked");
            return StatusCode((int)HttpStatusCode.OK, "Back - Success, 200");
        }

        // GET api/values/warning
        [HttpGet("warning")]
        public ActionResult<string> GenerateWarning()
        {
            Console.WriteLine("GenerateWarning got invoked");
            return StatusCode((int)HttpStatusCode.BadRequest, "Back - Warning, 400");
        }

        // GET api/values/error
        [HttpGet("error")]
        public ActionResult<string> GenerateError()
        {
            Console.WriteLine("GenerateError got invoked");
            Console.Error.WriteLine("GenerateError generate error to standard output (this is from standard output)");
            return StatusCode((int)HttpStatusCode.InternalServerError, "Back - Error, 500");
        }

        // POST api/values/back
        [HttpPost("back")]
        public ActionResult<ValuesResponseModel> PostBack(ValuesRequestModel backInput)
        {
            Console.WriteLine("PostBack got invoked");
            ValuesResponseModel output = new ValuesResponseModel()
            {
                output = backInput.input + " back is healthy" 
            };
            return output;
        }

        // POST api/values/throwerror
        [HttpGet("throwerror")]
        public ActionResult<string> ThrowError()
        {
            Console.WriteLine("ThrowError got invoked");

            throw new Exception("Exception thrown");

            return "Impossible";
        }

    }
}
