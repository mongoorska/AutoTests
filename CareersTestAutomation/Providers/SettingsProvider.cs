using System;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace CareersTestAutomation.Providers
{
    public static class SettingsProvider
    {
        private static string _projectPath;

        public static string HostName { get { return ConfigurationManager.AppSettings["hostName"]; } }

        public static string ProjectPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_projectPath))
                {
                    return _projectPath;
                }
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                if (assemblyLocation != null)
                {
                    string projectFolder = Path.GetFullPath(Path.Combine(assemblyLocation, @"..\..\..\"));

                    _projectPath = Path.Combine(projectFolder);
                }
                return _projectPath;
            }
        }
    }
}