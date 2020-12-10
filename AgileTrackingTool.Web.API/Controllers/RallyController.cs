using AgileTrackingTool.Web.API.Models;
using AgileTrackingTool.Web.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileTrackingTool.Web.API.Controllers
{
    [RoutePrefix("api/rally")]
    public class RallyController : ApiController
    {
        private readonly RallyService _rallyService = new RallyService();

        [HttpGet]
        [Route("authorized/{username}/{password}")]
        public IHttpActionResult GetAuthorized(string username, string password)
        {
            if (_rallyService.IsAuthorizeUser(username, password))
            {
                return Ok("Authorized");
            }

            return Unauthorized();
        }

        [Route("userstories/{username}/{password}")]
        [HttpGet]
        public IEnumerable<UserStoriesDetails> GetUserStoriesAndTaskAssigned(string username, string password)
        {
            var response = _rallyService.GetStoriesByUser(username, password);

            return response;
        }

        [Route("userinfo/{username}/{password}")]
        [HttpGet]
        public IHttpActionResult GetUserInfo(string username, string password)
        {
            var response = _rallyService.GetCurrentUserInfo(username, password);
           if(response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [Route("iteration/{username}/{password}/{project}")]
        [HttpGet]
        public IHttpActionResult GetAllIterations(string username, string password, string project)
        {
            var response = _rallyService.GetIterationDetails(username, password, project);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [Route("projectDetails/{username}/{password}/{projectname}")]
        [HttpGet]
        public IHttpActionResult GetProjectDetails(string username, string password, string projectname)
        {
            var response = _rallyService.GetProjectDetails(username, password, projectname);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}
