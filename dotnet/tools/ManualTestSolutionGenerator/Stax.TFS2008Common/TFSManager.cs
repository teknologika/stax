/*Copyright (c) 2010 Bruce McLeod
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation
and/or other materials provided with the distribution.

Neither the name of Stax nor the names of its contributors may be used to endorse or promote products derived from this
software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY ANDFITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Net;
using System.Net.Cache;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Security.Principal;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Stax.TFS2008Common
{
    /// <summary>
    /// The TfsManager class is responsible for connecting and managing the connection to the 
    /// Team Foundation Server. It is also used to retrieve certian data from the TFS Server.
    /// </summary>
    public sealed class TfsManager
    {
        /// <summary>
        /// A private constructor to allow the class to be static.
        /// </summary>
        private TfsManager() { }

        /// <summary>
        /// Gets the work item store from the TFS server.
        /// It will authenticate with the server if there is no prior connection to the  TFS server.
        /// If there is an existing connection, it will re-use the open connection.
        /// </summary>
        public static WorkItemStore TfsStore
        {
            get
            {
                // Retrieve the settings from the configuration files
                string serverName = ConfigurationManager.AppSettings["TFSServer"].ToString();
                TeamFoundationServer server = new TeamFoundationServer(serverName);
                WorkItemStore WIStore = new WorkItemStore(server);
                WIStore.TeamFoundationServer.Authenticate();
                return WIStore;
            }
        }

        /// <summary>
        /// Gets the collection of projects from TFS.
        /// </summary>
        public static ProjectCollection Projects
        {
            get
            {
                return TfsStore.Projects;
            }
        }

        /// <summary>
        /// Gets the display name of the current user.
        /// </summary>
        public static string DisplayName
        {
            get
            {
                return TfsStore.TeamFoundationServer.AuthenticatedUserDisplayName;
            }
        }

        /// <summary>
        /// Gets the user name of the current user.
        /// </summary>
        public static string UserName
        {
            get
            {
                return TfsStore.TeamFoundationServer.AuthenticatedUserName;
            }
        }

        /// <summary>
        /// Gets the collection of Allowed values for a certian field.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <param name="type">The selected type.</param>
        /// <param name="field">The TFS reference name of the field that is requesting the allowed values.</param>
        /// <returns>A collection of allowed values for the specified TFS field.</returns>
        public static AllowedValuesCollection GetAllowedValues(string project, string type, string field)
        {
            WorkItemType wiType = TfsStore.Projects[project].WorkItemTypes[type];

            if (wiType.FieldDefinitions.Contains(field))
            {
                return wiType.FieldDefinitions[field].AllowedValues;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the collection of Allowed values for a certian field.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <param name="field">The TFS reference name of the field that is requesting the allowed values.</param>
        /// <returns>A collection of allowed values for the specified TFS field.</returns>
        public static AllowedValuesCollection GetAllowedValues(string project, string field)
        {
            foreach (WorkItemType wit in TfsStore.Projects[project].WorkItemTypes)
            {
                if (wit.FieldDefinitions.Contains(field))
                {
                    return wit.FieldDefinitions[field].AllowedValues;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the TFS Reference Name for the field.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <param name="type">The selected type.</param>
        /// <param name="field">The TFS reference name of the field that is requesting the TFS reference name.</param>
        /// <returns>The TFS reference name.</returns>
        public static string GetReferenceName(string project, string type, string field)
        {
            WorkItemType wiType = TfsStore.Projects[project].WorkItemTypes[type];
            try
            {
                return wiType.FieldDefinitions[field].ReferenceName;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Gets the TFS Reference Name for the field.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <param name="type">The selected type.</param>
        /// <param name="field">The TFS reference name of the field that is requesting the TFS reference name.</param>
        /// <returns>The TFS reference name.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static string GetReferenceName(string field)
        {
            try
            {
                return TfsStore.FieldDefinitions[field].ReferenceName;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the collection of work item types from TFS.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <returns>A collection of work item types for the specified TFS project.</returns>
        public static WorkItemTypeCollection GetWITypes(string project)
        {
            return TfsStore.Projects[project].WorkItemTypes;
        }

        /// <summary>
        /// Given a set of parameters, this method builds the WIQL query to required to retrieve the work items.
        /// This overload also takes a sort column and direction.
        /// </summary>
        /// <param name="queryItems"></param>
        /// <param name="sortName">The column to be sorted.</param>
        /// <param name="sortDirection">ASC or DESC depending on how it is to be sorted.</param>
        /// <returns>The WIQL query generated.</returns>
        public static string GenerateWorkItemQuery(string query, string sortName, string sortDirection)
        {
            if (String.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("query", "The query passed is empty.");
            }
            StringBuilder sbOrder = new StringBuilder();

            sbOrder.Append(" ORDER BY ");
            sbOrder.Append("[");
            sbOrder.Append(sortName);
            sbOrder.Append("] ");
            sbOrder.Append(sortDirection);
            query = query.ToLower();
            if (query.Contains("order by"))
            {
                int orderByPosition = query.IndexOf(" order by");
                query = query.Substring(0, orderByPosition) + sbOrder.ToString();
            }
            else
            {
                query += sbOrder.ToString();
            }

            return query;
        }

        /// <summary>
        /// Given a set of parameters, this method builds the WIQL query to required to retrieve the work items.
        /// </summary>
        /// <param name="queryItems">The list of query parameters for the search.</param>
        /// <param name="searchItems">The list of select paramets for the search.</param>
        /// <returns>The WIQL query generated.</returns>
        public static string GenerateWorkItemQuery(Hashtable queryItems, List<string> searchItems, Hashtable orItems, string searchStr)
        {
            StringBuilder sbItems = new StringBuilder();
            StringBuilder sbCriteria = new StringBuilder();

            sbItems.Append("SELECT ");
            sbCriteria.Append(" WHERE ");

            int i = 0;
            foreach (string s in searchItems)
            {
                if (i == 0)
                {
                    sbItems.Append("[");
                }
                else
                {
                    sbItems.Append(", [");
                }

                sbItems.Append(s);
                sbItems.Append("]");
                i++;
            }

            i = 0;
            IDictionaryEnumerator itr = queryItems.GetEnumerator();
            while (itr.MoveNext())
            {
                if (itr.Value.ToString() != "All"
                    && !String.IsNullOrEmpty(itr.Value.ToString()))
                {
                    if (i != 0)
                    {
                        sbCriteria.Append("AND ");
                    }
                    sbCriteria.Append("[");
                    sbCriteria.Append(itr.Key.ToString());
                    sbCriteria.Append("] = '");
                    sbCriteria.Append(itr.Value.ToString());
                    sbCriteria.Append("' ");
                    i++;
                }
            }

            if (!String.IsNullOrEmpty(searchStr)
                && orItems != null)
            {
                sbCriteria.Append(" AND (");
                int j = 0;
                IDictionaryEnumerator orItr = orItems.GetEnumerator();
                while (orItr.MoveNext())
                {
                    Type currType = TfsStore.FieldDefinitions[orItr.Key.ToString()].SystemType;
                    if (currType == typeof(System.Int32))
                    {
                        try
                        {
                            Int32.Parse(searchStr);
                        }
                        catch
                        {
                            if (j == 0)
                            {
                                j = -1;
                            }
                            continue;
                        }
                    }
                    else if (currType == typeof(System.Double))
                    {
                        try
                        {
                            Double.Parse(searchStr);
                        }
                        catch
                        {
                            if (j == 0)
                            {
                                j = -1;
                            }
                            continue;
                        }
                    }
                    else if (currType == typeof(System.DateTime))
                    {
                        try
                        {
                            DateTime.Parse(searchStr);
                        }
                        catch
                        {
                            if (j == 0)
                            {
                                j = -1;
                            }
                            continue;
                        }
                    }

                    if (j != 0)
                    {
                        sbCriteria.Append("OR ");
                    }

                    sbCriteria.Append("[");
                    sbCriteria.Append(orItr.Key.ToString());
                    sbCriteria.Append("]");

                    if (orItr.Value.ToString() == "equals")
                    {
                        sbCriteria.Append(" = ");
                    }
                    else
                    {
                        sbCriteria.Append(" contains ");
                    }
                    sbCriteria.Append("'");
                    sbCriteria.Append(searchStr);
                    sbCriteria.Append("' ");
                    j++;
                }
                sbCriteria.Append(")");
            }

            string query = sbItems.ToString() + " FROM WorkItems ";

            if (sbCriteria.ToString() != " WHERE ")
            {
                query += sbCriteria.ToString();
            }

            return query;


        }

        /// <summary>
        /// Retrieves the work item from TFS using a work item Id.
        /// </summary>
        /// <param name="workItemId">The Id of the work item.</param>
        /// <returns>The work item object.</returns>
        public static WorkItem GetWorkItem(int workItemId)
        {
            return TfsStore.GetWorkItem(workItemId);
        }

        /// <summary>
        /// Executes the query on TFS and returns the work items relevant.
        /// </summary>
        /// <param name="wiql">The query to execute.</param>
        /// <returns>The collection of work items returned from the query.</returns>
        public static WorkItemCollection Query(string wiql)
        {
            return TfsStore.Query(wiql);
        }

        /// <summary>
        /// Executes the query on TFS and returns the work items relevant.
        /// </summary>
        /// <param name="wiql">The query to execute.</param>
        /// <param name="parameters">Parameters used within the query.</param>
        /// <returns>The collection of work items returned from the query.</returns>
        public static WorkItemCollection Query(string wiql, Hashtable parameters)
        {
            return TfsStore.Query(wiql, parameters);
        }

        /// <summary>
        /// Gets the collection of public and private queries.
        /// </summary>
        /// <param name="projectName">The project from which the queries is to be retrieved from.</param>
        /// <returns>The collection of queries within the project.</returns>
        public static StoredQueryCollection GetStoredQueries(string projectName)
        {
            TfsStore.Projects[projectName].StoredQueries.Refresh();
            return TfsStore.Projects[projectName].StoredQueries;
        }
    }
}
