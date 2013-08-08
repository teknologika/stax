using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stax.TFS2010;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Collections;

using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.Build.Client; 

namespace VS2010TestResultPublisher
{
    public class TFS2010ResultWriter : IResultsWriter
    {

        internal Settings _settings;
        private static TFS2010ResultWriter _instance = null;
        static readonly object threadSafeLock = new object();
        private TeamFoundationServer server = null;
        private WorkItemStore store = null;
        private Project project = null;
        private IGroupSecurityService gss = null;
        private Identity SIDS = null;
        private Identity[] TFSUsers = null;
        private string friendlyUserName = null;
        private string buildToPublish = String.Empty;

        private TFS2010ResultWriter()
        {
            _settings = new Settings();
        }

        /// <summary>
        /// Public method that will return the class -> singleton
        /// </summary>
        /// <returns>ControlHandler</returns>
        public static TFS2010ResultWriter Instance(ProjectSettings projectContext, bool createRun)
        {
            // thread safe singleton code
            lock (threadSafeLock)
            {
                if (_instance == null)
                {
                    _instance = new TFS2010ResultWriter();
                    _instance.CurrentProject = projectContext;
                    TFSDialog dialog = new TFSDialog(_instance.GetBuilds());
                    dialog.ShowDialog();
                    _instance.buildToPublish = dialog.Build;
                    if (createRun)
                    {
                       // _instance.CreateTestRun();
                    }
                }
                return _instance;
            }
        }

        public override string UpdateTestResult(TestResult result, bool publishFailures, bool publishInconclusive, bool publishErrorInformation)
        {
            string resultString = "You should never see this.";
            if (result == null)
            {
                return "No test result was passed to publish.";
            }

            if (result.TFSWorkItemId.ToString() == null)
            {
                return "The test " + result.TestName + " does not have a linked work item ID in TFS.";
            }

            bool publishResult = false;
            switch (result.Outcome)
            {
                case TestResult.TestResultType.Aborted:
                    resultString = "The test " + result.TestName + " has aborted will not be published.";
                    publishResult = false;
                    break;

                case TestResult.TestResultType.Passed:
                    publishResult = true;
                    break;
                case TestResult.TestResultType.Failed:
                    if (publishFailures)
                    {
                        publishResult = true;
                    }
                    else
                    {
                        resultString = "The test " + result.TestName + " has failed will not be published.";
                        publishResult = false;
                    }
                    break;
                case TestResult.TestResultType.Inconclusive:
                    if (publishInconclusive)
                    {
                        publishResult = true;
                    }
                    else
                    {
                        resultString = "The test " + result.TestName + " was inconclusive will not be published.";
                        publishResult = false;
                    }
                    break;
                case TestResult.TestResultType.NotExecuted:
                    publishResult = false;
                    break;
            }

            if (publishResult)
            {

                bool projectFound = false;
                try
                {
                    if (store == null)
                    {

                        server = new TeamFoundationServer(CurrentProject.DomainUri);
                        server.Authenticate();
                        store = (WorkItemStore)server.GetService(typeof(WorkItemStore));
                    }
                }
                catch (Exception e)
                {
                    return "Unable to connect to the TFS server: " + CurrentProject.DomainName + ". The error was: " + e.Message;
                }

                // Before we load the project, let's check the user name is valid
                if (!CheckTfsUserIsValid(result.ExecutedBy))
                {
                    return "The user " + result.ExecutedBy + " is not a valid TFS user, The test " + result.TestName + " will not be published.";
                }

                // Select the TFS project to connect to
                foreach (Project item in store.Projects)
                {
                    if (item.Name.ToLower() == CurrentProject.ProjectName.ToLower())
                    {
                        project = item;
                        projectFound = true;
                        break;
                    }
                }

                if (projectFound)
                {
                    WorkItem workItem = GetWorkItem(result.TFSWorkItemId);
                    if (workItem != null)
                    {
                        if (_settings.ExecutedByField != "")
                        {
                            workItem.Fields[_settings.ExecutedByField].Value = friendlyUserName;
                        }
                        if (_settings.ExecutionStatusField != "")
                        {
                            workItem.Fields[_settings.ExecutionStatusField].Value = result.OutcomeAsString;
                        }
                        if (_settings.ExecutionEnvironmentField != "")
                        {
                            workItem.Fields[_settings.ExecutionEnvironmentField].Value = result.ExecutionEnvironment;
                        }
                        if (_settings.ExecutedInBuild != "")
                        {
                            workItem.Fields[_settings.ExecutedInBuild].Value = buildToPublish;
                        }
                        if (_settings.ExecutionTimeField != "")
                        {
                            workItem.Fields[_settings.ExecutionTimeField].Value = result.ExecutionDateTimeString;
                        }
                        if (publishErrorInformation)
                        {
                            if (_settings.ExecutionCommentField != "")
                            {
                                workItem.Fields[_settings.ExecutionCommentField].Value = result.ExecutionComments;
                            }
                        }

                        try
                        {
                            workItem.Save();
                        }
                        catch (Exception e)
                        {

                            return "ERROR: Unable to publish " + result.TestName + e.Message;
                        }
                        return result.TestName + " was published successfully.";
                    }
                }
                else
                {
                    return "The project " + CurrentProject.ProjectName + " was not found.";
                }
                return "The work item " + result.TFSWorkItemId + " does not exist." + result.TestName + " could not be published";
            }
            else
            {
                return resultString;
            }
        }

        private bool CheckTfsUserIsValid(string value)
        {
            if (TFSUsers == null)
            {
                GetTFSUsersFromServer();
            }

            foreach (Identity user in TFSUsers)
            {
                if (value.ToUpper() == user.Domain.ToUpper() + @"\" + user.AccountName.ToUpper())
                {
                    friendlyUserName = user.DisplayName;
                    return true;
                }
            }
            return false;
        }

        private void GetTFSUsersFromServer()
        {
            try
            {
                gss = (IGroupSecurityService)server.GetService(typeof(IGroupSecurityService));
                SIDS = gss.ReadIdentity(SearchFactor.AccountName, _settings.TeamFoundationServerUserGroup, QueryMembership.Expanded);
                TFSUsers = gss.ReadIdentities(SearchFactor.Sid, SIDS.Members, QueryMembership.None);

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.InnerException.ToString(), e.Message);
            }

        }

        private void GetFriendlyUsername(string userName)
        {
            if (TFSUsers == null)
            {
                GetTFSUsersFromServer();
            }

        }

        public ProjectCollection GetProjects()
        {
            return store.Projects;
        }

        public AllowedValuesCollection GetWorkItemTypes()
        {
            return store.FieldDefinitions[CoreField.WorkItemType].AllowedValues;
        }

        public AllowedValuesCollection GetWorkItemStates(string workItemType)
        {
            WorkItemType type = project.WorkItemTypes[workItemType];
            return type.FieldDefinitions[CoreField.State].AllowedValues;
        }

        public WorkItem GetWorkItem(int workItemId)
        {

            try
            {
                return store.GetWorkItem(workItemId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public WorkItemCollection RetrieveWorkItems()
        {
            Hashtable parameters = BuildParameters();
            string query = BuildQuery();
            return store.Query(query, parameters);
        }

        private string BuildQuery()
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT [System.Id], [System.WorkItemType], [System.AssignedTo], ");
            queryBuilder.Append("[System.CreatedBy], [Microsoft.VSTS.Common.Priority], [System.Title] ");
            queryBuilder.Append("FROM WorkItems WHERE [System.TeamProject] = @project ");
            queryBuilder.Append(" ORDER BY [System.ChangedDate] desc, [System.State], [System.WorkItemType], [System.Title]");
            return queryBuilder.ToString();
        }

        public WorkItemCollection RetrieveTestCases()
        {
            Hashtable parameters = BuildParameters();
            string query = BuildTestCasesQuery();
            return store.Query(query, parameters);
        }

        private string BuildTestCasesQuery()
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT [System.Id], [System.WorkItemType], [System.AssignedTo], ");
            queryBuilder.Append("[System.CreatedBy], [Microsoft.VSTS.Common.Priority], [System.Title] ");
            queryBuilder.Append("FROM WorkItems WHERE [System.TeamProject] = @project AND [System.WorkItemType] = \"Test Case\"");
            queryBuilder.Append(" ORDER BY [System.ChangedDate] desc, [System.State], [System.WorkItemType], [System.Title]");
            return queryBuilder.ToString();
        }

        private Hashtable BuildParameters()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("project", project.Name);
            return parameters;
        }

        public List<string> GetBuilds()
        {
            try
            {

                server = new TeamFoundationServer(CurrentProject.DomainUri);
                server.Authenticate();
                IBuildServer buildStore = (IBuildServer)server.GetService(typeof(IBuildServer));

                IBuildDetail[] buildList = buildStore.QueryBuilds(CurrentProject.ProjectName, "Daily Build");

                List<string> builds = new List<string>();

                foreach (IBuildDetail bd in buildList)
                {
                    builds.Add(bd.BuildNumber);
                }

                builds.Reverse();

                return builds;
            }
            catch
            {
                return new List<string>();
            }
        }

        private string CreateTestRun()
        {
            bool projectFound = false;
            try
            {
                if (store == null)
                {

                    server = new TeamFoundationServer(CurrentProject.DomainUri);
                    server.Authenticate();
                    store = (WorkItemStore)server.GetService(typeof(WorkItemStore));
                }
            }
            catch (Exception e)
            {
                return "Unable to connect to the TFS server: " + CurrentProject.DomainName + ". The error was: " + e.Message;
            }


            // Select the TFS project to connect to
            foreach (Project item in store.Projects)
            {
                if (item.Name.ToLower() == CurrentProject.ProjectName.ToLower())
                {
                    project = item;
                    projectFound = true;
                    break;
                }
            }

            if (projectFound)
            {

                WorkItemCollection workItemList = RetrieveTestCases();
                foreach (WorkItem workItem in workItemList)
                {
                    if (workItem.State != "Obsolete")
                    {
                        workItem.Open();
                        if (_settings.ExecutedByField != "")
                        {
                            workItem.Fields[_settings.ExecutedByField].Value = store.TeamFoundationServer.AuthenticatedUserDisplayName;
                        }
                        if (_settings.ExecutionStatusField != "")
                        {
                            workItem.Fields[_settings.ExecutionStatusField].Value = "Not Run";
                        }
                        if (_settings.ExecutionEnvironmentField != "")
                        {
                            workItem.Fields[_settings.ExecutionEnvironmentField].Value = "";
                        }
                        if (_settings.ExecutedInBuild != "")
                        {
                            workItem.Fields[_settings.ExecutedInBuild].Value = buildToPublish;
                        }
                        if (_settings.ExecutionTimeField != "")
                        {
                            workItem.Fields[_settings.ExecutionTimeField].Value = DateTime.Now.ToString();
                        }
                        try
                        {
                            workItem.Save();
                        }
                        catch
                        {
                            return "ERROR: Unable to create run";
                        }

                    }
                }
                return "Run for build " + buildToPublish + " was created successfully.";
            }
            else
            {
                return "The project " + CurrentProject.ProjectName + " was not found.";
            }
        }
    }
}
