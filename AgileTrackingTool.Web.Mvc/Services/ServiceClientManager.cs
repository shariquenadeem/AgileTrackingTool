using AgileTrackingTool.Web.API.Models;
using Newtonsoft.Json;
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                var responseTask = client.GetAsync(string.Concat(serverUrl, (string.Format("userinfo/{0}/{1}", username, password))));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    return JsonConvert.DeserializeObject<UserInfo>(readTask.Result);
                }

                return new UserInfo();
            }
        }

        public ProjectDetails GetProjectDetails(string username, string password, string projectName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                var responseTask = client.GetAsync(string.Concat(serverUrl, (string.Format("projectDetails/{0}/{1}/{2}", username, password, projectName))));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    return JsonConvert.DeserializeObject<ProjectDetails>(readTask.Result);
                }

                return new ProjectDetails();
            }
        }

        public IList<UserStoriesDetails> GetStoriesByUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                var responseTask = client.GetAsync(string.Concat(serverUrl, (string.Format("userstories/{0}/{1}", username, password))));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    return JsonConvert.DeserializeObject<UserStoriesDetails[]>(readTask.Result);
                }

                return new List<UserStoriesDetails>();
            }
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
