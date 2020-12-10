using AgileTrackingTool.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AgileTrackingTool.Web.Mvc.Services
{
    public class ServiceClientManager : IServiceClientManager
    {
        private readonly string serverUrl = "https://localhost:44309/api/rally/";
        public ServiceClientManager()
        {

        }

        public IEnumerable<UserStoriesDetails> GetAllDetailsIteration()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetCurrentUserInfo(string username, string password)
        {
            throw new NotImplementedException();
        }

        public ProjectDetails GetProjectDetails(string projectName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserStoriesDetails> GetStoriesByUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthorizeUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(serverUrl);
                var responseTask = client.GetAsync(string.Concat(serverUrl,(string.Format("authorized/{0}/{1}", username, password))));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
