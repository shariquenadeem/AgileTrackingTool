using AgileTrackingTool.Web.API.Models;
using Rally.RestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public ProjectDetails GetProjectDetails(string projectName)
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

        public IEnumerable<UserStoriesDetails> GetStoriesByUser(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserStoriesDetails> GetAllDetailsIteration()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetCurrentUserInfo(string username, string password)
        {
            UserInfo userInfo;
            restApi.Authenticate(username, password, serverUrl, proxy: null, allowSSO: false);
            if (restApi.AuthenticationState == RallyRestApi.AuthenticationResult.Authenticated)
            {
                userInfo = new UserInfo();
                var response = restApi.GetCurrentUser();
                userInfo.EmailAddress = response["EmailAddress"];
                userInfo.FirstName = response["FirstName"];
                userInfo.LastName = response["LastName"];
                userInfo.UserName = response["UserName"];

                return userInfo;
            }

            return null;
        }
    }
}