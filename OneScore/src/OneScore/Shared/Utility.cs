using System;
using System.Web.Configuration;
namespace OneScore.Shared
{
    public static class Utility
    {
        public static string FootballDataApiUrl { get { return GetConfigValue("FootballDataApiUrl"); } }
        public static string FootballDataApiKey { get { return GetConfigValue("FootballDataApiKey"); } }

        public static string GetConfigValue(string Key)
        {
            if (String.IsNullOrWhiteSpace(Key))
                return "";
            return WebConfigurationManager.AppSettings[Key];


        }
    }
}
