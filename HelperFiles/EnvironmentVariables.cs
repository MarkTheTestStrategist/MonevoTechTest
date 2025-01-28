using dotenv.net;
using System.Collections.Generic;

namespace monevotechtest.HelperFiles
{
    internal static class EnvironmentVariables
    {
        private static readonly IDictionary<string, string> envVars = DotEnv.Read();

        public static string Get(string key)
        {
            return envVars.ContainsKey(key) ? envVars[key] : null;
        }
    }
}