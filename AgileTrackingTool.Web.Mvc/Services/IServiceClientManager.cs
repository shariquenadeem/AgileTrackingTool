using AgileTrackingTool.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.Mvc.Services
{
    public interface IServiceClientManager
    {
        UserInfo GetCurrentUserInfo(string username, string password);
        bool IsAuthorizeUser(string username, string password);
        ProjectDetails GetProjectDetails(string username, string password,string projectName);
        IEnumerable<UserStoriesDetails> GetStoriesByUser(string username);
        IEnumerable<UserStoriesDetails> GetAllDetailsIteration();
    }
}
