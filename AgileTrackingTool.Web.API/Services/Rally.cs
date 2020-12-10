﻿using Rally.RestApi;
using Rally.RestApi.Json;
using Rally.RestApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.API.Services
{
    public class Rally
    {
        private RallyRestApi restApi;
        public bool IsAuthenticated { get; set; }
        public Rally(string username, string password)
        {
            string serverUrl = "https://rally1.rallydev.com/";

            restApi = new RallyRestApi();
            restApi.Authenticate(username, password, serverUrl, proxy: null, allowSSO: false);

            if (restApi.AuthenticationState != RallyRestApi.AuthenticationResult.Authenticated)
            {
                IsAuthenticated = false;
            }
            else
            {
                IsAuthenticated = true;
            }
        }

        /// <summary>
        /// Gives the current user details 
        /// </summary>
        /// <returns></returns>
        public QueryResult GetCurrentUserDetails()
        {
            return restApi.GetCurrentUser();
        }

        public QueryResult GetAllTeamMembers(dynamic project)
        {
            Request teamRequest = new Request(project["TeamMembers"]);
            teamRequest.Limit = 10000;
            return restApi.Query(teamRequest);
        }

        /// <summary>
        /// Gives all work spaces present in the env
        /// </summary>
        /// <returns></returns>
        public QueryResult GetAllWorkSpaces()
        {
            DynamicJsonObject sub = restApi.GetSubscription("Workspaces");
            Request wRequest = new Request(sub["Workspaces"]);
            wRequest.Limit = 1000;
            return restApi.Query(wRequest);
        }

        /// <summary>
        /// Gives all projects inside a workspace, below is an example
        ///             var workspace = rally.GetAllWorkSpaces().Results.First();
        ///             var projects = rally.GetAllProjects(workspace);
        /// </summary>
        /// <param name="artifactName"></param>
        /// <returns></returns>
        public QueryResult GetAllProjects(dynamic artifactName)
        {
            Request projectsRequest = new Request(artifactName["Projects"]);
            projectsRequest.Limit = 10000;
            return restApi.Query(projectsRequest);
        }


        /// <summary>
        /// Gives project details for given project name insilde project query result, below is an example
        ///             var projects =  rally.GetAllProjects(workspace);
        ///             var atlas = rally.GetProject("Sales ART - Team Calypso", projects);
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="projects"></param>
        /// <returns></returns>
        public DynamicJsonObject GetProject(string projectName, QueryResult projects)
        {
            return projects.Results.Select(item => item).Where(project => project["Name"] == "Sales ART - Team Calypso").First();
        }

        /// <summary>
        /// Gives all defects
        /// </summary>
        /// <returns></returns>
        public QueryResult GetAllDefects()
        {
            return restApi.GetAttributesByType("defect");
        }

        /// <summary>
        /// Gives iteration detials for a given project, below is an example
        ///             var atlas = rally.GetProject("Sales ART - Team Calypso", projects);
        ///             var Itrs = rally.GetItrs(atlas);
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public QueryResult GetItrs(dynamic project)
        {
            Request itrRequest = new Request(project["Iterations"]);
            itrRequest.Limit = 10000; //project requests are made per workspace
            return restApi.Query(itrRequest);
        }


        public int GetTotalUserStories()
        {
            int storyCount = 0;
            String projectRef = "/project/27874475461";     //replace this OID with an OID of your workspace

            Request sRequest = new Request("HierarchicalRequirement");
            sRequest.Project = projectRef;
            sRequest.Fetch = new List<string>() { "FormattedID", "Name", "Tasks" };
            //sRequest.Query = new Query("(Iteration.StartDate <= Today)");
            sRequest.Limit = 100000;
            QueryResult queryResults = restApi.Query(sRequest);


            foreach (var s in queryResults.Results)
            {
                Console.WriteLine("FormattedID: " + s["FormattedID"] + " Name: " + s["Name"]);
                storyCount++;
            }
            return storyCount;
        }
    }
}