using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TeamFoundation;

namespace VS2010TestResultPublisher
{
    public class ProjectSettings
    {
        public ProjectSettings(string serverUrl, string domainName, string projectName, string userName, string password)
        {
            ServerURL = serverUrl;
            DomainName = domainName;
            ProjectName = projectName;
            Username = userName;
            Password = password;
        }

        public ProjectSettings(ProjectContextExt ext)
        {
            DomainName = ext.DomainName;
            DomainUri = ext.DomainUri;
            ProjectName = ext.ProjectName;
            ProjectUri = ext.ProjectUri;

        }

        public string ServerURL { get; set; }
        public string DomainName { get; set; }
        public string DomainUri { get; set; }
        public string ProjectName { get; set; }
        public string ProjectUri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
