using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend_coding_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmptyController : ControllerBase
    {
        [HttpGet]
        public EmptyModel Get()
        {
            return new EmptyModel();
        }
    }
}
