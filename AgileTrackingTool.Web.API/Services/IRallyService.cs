using AgileTrackingTool.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.API.Services
{
    public interface IRallyService
    {
        UserInfo GetCurrentUserInfo(string username, string password);
        bool IsAuthorizeUser(string username, string password);
        ProjectDetails GetProjectDetails(string projectName);
        IEnumerable<UserStoriesDetails> GetStoriesByUser(string username);
        IEnumerable<UserStoriesDetails> GetAllDetailsIteration();
    }
}
