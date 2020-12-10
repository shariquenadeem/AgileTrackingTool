using AgileTrackingTool.Web.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.API.Services
{
    public interface IRallyService
    {
        UserInfo GetCurrentUserInfo();
        bool IsAuthorizeUser(string username, string password);
        ProjectDetails GetProjectDetails(string projectName);
        UseStoriesDetails GetStoriesByUser(string username);
        UseStoriesDetails GetAllDetailsIteration();
    }
}
