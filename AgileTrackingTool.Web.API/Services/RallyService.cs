using AgileTrackingTool.Web.API.Models;
using Rally.RestApi;
using Rally.RestApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTrackingTool.Web.API.Services
{
    public class RallyService : IRallyService
    {
        private RallyRestApi restApi;
        private Rally rally;
        private readonly string serverUrl = "https://rally1.rallydev.com/";
        public RallyService()
        {
            restApi = new RallyRestApi();
        }

        public ProjectDetails GetProjectDetails(string username, string password, string projectName)
        {
            rally = new Rally(username, password);
            var workspace = rally.GetAllWorkSpaces().Results.First();
            var projects = rally.GetAllProjects(workspace);
            var atlas = rally.GetProject(projectName, projects);
            var defects = rally.GetAllDefects();
            ProjectDetails projectDetails = new ProjectDetails();
            projectDetails.TotalIteration = rally.GetItrs(atlas).Results.Count;
            projectDetails.TotalUsers = rally.GetAllTeamMembers(atlas).Results.Count;
            //projectDetails.TotalDefects = rally.GetAllTeamMembers(atlas).Results.Count;

            return projectDetails;
        }

        public IEnumerable<IterationDetails> GetIterationDetails(string username, string password, string projectName)
        {
            rally = new Rally(username, password);
            var workspace = rally.GetAllWorkSpaces().Results.First();
            var projects = rally.GetAllProjects(workspace);
            var atlas = rally.GetProject(projectName, projects);
            var Itrs = rally.GetItrs(atlas);
            List<IterationDetails> AllIterationDetails = new List<IterationDetails>();
            
            foreach(var itr in Itrs.Results)
            {
                IterationDetails iterationDetails = new IterationDetails();
                iterationDetails.Name = itr["Name"];
                iterationDetails.StartDate = itr["StartDate"];
                iterationDetails.EndDate = itr["EndDate"];
                iterationDetails.State = itr["State"];
                AllIterationDetails.Add(iterationDetails);
            }

            return AllIterationDetails;
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

        public IEnumerable<UserStoriesDetails> GetStoriesByUser(string username, string password)
        {
            restApi.Authenticate(username, password, serverUrl, proxy: null, allowSSO: false);

            List<UserStoriesDetails> allUserStoriesDetails = new List<UserStoriesDetails>();
            String projectRef = "/project/27874475461";

            Request sRequest = new Request("HierarchicalRequirement");
            sRequest.Project = projectRef;
            sRequest.Query = new Query("Owner", Query.Operator.Equals, username);
            sRequest.Limit = 10000;
            QueryResult queryResults = restApi.Query(sRequest);

            foreach (var s in queryResults.Results)
            {
                UserStoriesDetails userStoriesDetails = new UserStoriesDetails();
                userStoriesDetails.AssignedOwner = s["Owner"]["_refObjectName"];
                userStoriesDetails.Description = s["Description"];
                userStoriesDetails.Name = s["Name"];
                userStoriesDetails.Id = s["FormattedID"];
                userStoriesDetails.CreatedDate = s["CreationDate"];
                userStoriesDetails.UpdatedDate = s["LastUpdateDate"];
                userStoriesDetails.Status = s["ScheduleState"];

                userStoriesDetails.Tasks = null;

                allUserStoriesDetails.Add(userStoriesDetails);
            }
            return allUserStoriesDetails.Count > 0 ? allUserStoriesDetails : null;
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