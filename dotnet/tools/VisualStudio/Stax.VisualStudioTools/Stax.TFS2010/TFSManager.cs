using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Stax.TFS2010
{
    public sealed class  TFSManager
    {
        /// <summary>
        /// A private constructor to allow the class to be static.
        /// </summary>
        private TFSManager() { }

        /// <summary>
        /// Gets the work item store from the TFS server.
        /// It will authenticate with the server if there is no prior connection to the  TFS server.
        /// If there is an existing connection, it will re-use the open connection.
        /// </summary>
        public static WorkItemStore TFSStore
        {
            get
            {
                // Retrieve the settings from the configuration files
                Uri collectionUri = Helper.GetCollectionUri();
                TfsTeamProjectCollection projectCollection;
                WorkItemStore WIStore = null;
                try
                {
                    projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri);
                    WIStore = projectCollection.GetService<WorkItemStore>();
                }
                catch (Exception ex)
                {
                    LogWriter.WriteTextToLogFile(ex.Message);
                }
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
                return TFSStore.Projects;
            }
        }





        /// <summary>
        /// Gets the collection of Allowed values for a certain field.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <param name="type">The selected type.</param>
        /// <param name="field">The TFS reference name of the field that is requesting the allowed values.</param>
        /// <returns>A collection of allowed values for the specified TFS field.</returns>
        public static AllowedValuesCollection GetAllowedValues(string project, string type, string field)
        {
            WorkItemType wiType = TFSStore.Projects[project].WorkItemTypes[type];

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
        /// Gets the heirachy of queries.
        /// </summary>
        /// <param name="projectName">The project from which the queries is to be retrieved from.</param>
        /// <returns>The QueryHeirachy of queries within the project.</returns>
        public static QueryHierarchy GetStoredQueries(string projectName)
        {
            return TFSStore.Projects[projectName].QueryHierarchy;

        }

        /// <summary>
        /// Gets the collection of work item types from TFS.
        /// </summary>
        /// <param name="project">The selected project.</param>
        /// <returns>A collection of work item types for the specified TFS project.</returns>
        public static WorkItemTypeCollection GetWITypes(string project)
        {
            return TFSStore.Projects[project].WorkItemTypes;
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
                    Type currType = TFSStore.FieldDefinitions[orItr.Key.ToString()].SystemType;
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
            return TFSStore.GetWorkItem(workItemId);
        }

        /// <summary>
        /// Executes the query on TFS and returns the work items relevant.
        /// </summary>
        /// <param name="wiql">The query to execute.</param>
        /// <returns>The collection of work items returned from the query.</returns>
        public static WorkItemCollection Query(string wiql)
        {
            return TFSStore.Query(wiql);
        }

        /// <summary>
        /// Executes the query on TFS and returns the work items relevant.
        /// </summary>
        /// <param name="wiql">The query to execute.</param>
        /// <param name="parameters">Parameters used within the query.</param>
        /// <returns>The collection of work items returned from the query.</returns>
        public static WorkItemCollection Query(string wiql, Hashtable parameters)
        {
            return TFSStore.Query(wiql, parameters);
        }
    }
}
