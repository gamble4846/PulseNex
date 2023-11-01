using Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Helpers
{
    public class CommonService
    {
        public CommonService()
        {

        }

        public static bool IsDebug()
        {
            #if DEBUG
                return true;
            #else
                return false;
            #endif
        }

        public static AppSettingsModel GetAppSettings()
        {
            AppSettingsModel model = new AppSettingsModel();
            var appSettingsLocation = "";

            if (IsDebug())
            {
                appSettingsLocation = "D:/Git Projects/My Projects/PulseNex/PulseNexAPI/PulseNex/PulseNex/ConfigFiles/appsettings.json";
            }
            else 
            {
                appSettingsLocation = "/app/ConfigFiles/appsettings.json";
            }

            bool flag = File.Exists(appSettingsLocation);
            string contents = File.ReadAllText(appSettingsLocation);

            model = JsonConvert.DeserializeObject<AppSettingsModel>(contents);

            return model;
        }
    }
}
