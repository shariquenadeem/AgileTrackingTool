using AgileTrackingTool.Web.API.Model;
using Rally.RestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.API.Services
{
    public class RallyService : IRallyService
    {
        private RallyRestApi restApi;
        private readonly string serverUrl = "https://rally1.rallydev.com/";
        public RallyService()
        {
            restApi = new RallyRestApi();
        }

        public UseStoriesDetails GetAllDetailsIteration()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetCurrentUserInfo()
        {
            throw new NotImplementedException();
        }

        public ProjectDetails GetProjectDetails(string projectName)
        {
            throw new NotImplementedException();
        }

        public UseStoriesDetails GetStoriesByUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthorizeUser(string username, string password)
        {
            restApi.Authenticate(username, password, serverUrl, proxy: null, allowSSO: false);
            if (restApi.AuthenticationState != RallyRestApi.AuthenticationResult.Authenticated)
            {
                return false;
            }

            return true;
        }
    }
}
