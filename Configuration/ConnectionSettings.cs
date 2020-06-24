using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApi.Web.Configuration
{
    public class ConnectionSettings
    {
        public string IdentityConnection { get; set; }
        public string JungleDbConnection { get; set; }
        public string AzureDbConnection { get; set; }
    }

}
