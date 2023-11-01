using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Model
{
    public class AppSettingsModel
    {
        public AppSettingsModel_JWT Jwt { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class AppSettingsModel_JWT
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Secret { get; set; }
    }
}
