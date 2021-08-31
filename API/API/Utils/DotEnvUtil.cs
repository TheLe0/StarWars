using dotenv.net;
using System.Collections.Generic;

namespace API.Utils
{
    public class DotEnvUtil
    {
        public IDictionary<string, string> EnvVars { private set; get; }

        public DotEnvUtil()
        {
            DotEnv.Load();
            this.PopulateEnvVars();
        }

        private void PopulateEnvVars()
        {
            this.EnvVars = DotEnv.Read();
        }
    }
}