using System;
using System.Configuration;

namespace VS2010TestResultPublisher
{

    internal class Settings
    {
        public string TeamFoundationServerUserGroup = ConfigParser.TeamFoundationServerUserGroup;
        public string ExecutionStatusField = ConfigParser.ExecutionStatusField;
        public string ExecutionEnvironmentField = ConfigParser.ExecutionEnvironmentField;
        public string ExecutionTimeField = ConfigParser.ExecutionTimeField;
        public string ExecutedByField = ConfigParser.ExecutedByField;
        public string ExecutedInBuild = ConfigParser.ExecutedInBuild;
        public string ExecutionCommentField = "";
    }

    public class ConfigParser
    {
        public static string TeamFoundationServerUserGroup { get; set; }
        public static string ExecutionStatusField { get; set; }
        public static string ExecutionEnvironmentField { get; set; }
        public static string ExecutionTimeField { get; set; }
        public static string ExecutedByField { get; set; }
        public static string ExecutedInBuild { get; set; }
        public static string ExecutionCommentField { get; set; }

        public static void LoadConfiguration()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (!path.EndsWith("\\"))
            {
                path = path + "\\";
            }

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();

            fileMap.ExeConfigFilename = path + "Visual Studio 2010\\Addins\\App.config";


            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            TeamFoundationServerUserGroup = config.AppSettings.Settings["TeamFoundationServerUserGroup"].Value;
            ExecutionStatusField = config.AppSettings.Settings["ExecutionStatusField"].Value;
            ExecutionEnvironmentField = config.AppSettings.Settings["ExecutionEnvironmentField"].Value;
            ExecutionTimeField = config.AppSettings.Settings["ExecutionTimeField"].Value;
            ExecutedByField = config.AppSettings.Settings["ExecutedByField"].Value;
            ExecutionCommentField = config.AppSettings.Settings["ExecutionCommentField"].Value;
            ExecutedInBuild = config.AppSettings.Settings["ExecutedInBuild"].Value;
        }
    }
  
}
