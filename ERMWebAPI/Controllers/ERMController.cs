using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERMWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMWebAPI.Controllers
{
    [Route("v1/ERMCalculations")]
    [ApiController]
    public class ERMController : ControllerBase
    {
        private readonly IERMLogic _ermlogic;

        public ERMController(IERMLogic ermlogic)
        {
            _ermlogic = ermlogic;
        }
        [HttpGet]
        public IActionResult GetERMCalculations(string date,string datatype,string filename) {
            var result = _ermlogic.GetCalculations(date,datatype,filename);
            return Ok(result);
        }


    }
}