using AgileTrackingTool.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AgileTrackingTool.Web.Mvc.Services
{
    public class ServiceClientManager : IServiceClientManager
    {
        private readonly string serverUrl = "http://localhost:60464/api/rally/";
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
                //HTTP GET
                var responseTask = client.GetAsync("authorized/{username}/{password}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    //var readTask = result.Content.ReadAsAsync();
                    //readTask.Wait();

                    //var students = readTask.Result;

                    //foreach (var student in students)
                    //{
                    //    Console.WriteLine(student.Name);
                    //}
                }
            }
            //Console.ReadLine();
            return true;
        }
    }
}
