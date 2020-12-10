using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTrackingTool.Web.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileTrackingTool.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RallyController : ControllerBase
    {
        private readonly IRallyService _rallyService = new RallyService();
        
        [HttpGet]
        public ActionResult IsAuthorizeUser([FromQuery] string username, [FromQuery]string password)
        {
            if (_rallyService.IsAuthorizeUser(username, password))
                return Ok("Authorized");
            return Unauthorized("Failed");

        }
    }
}