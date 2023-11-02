using Newtonsoft.Json;
using PulseNex.Model;

namespace PulseNex.Helpers
{
    public class CommonHelper
    {
        public CommonHelper()
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

        public static string GetAppSettingsFileLocation()
        {
            string appSettingsLocation = "";
            if (CommonHelper.IsDebug())
            {
                appSettingsLocation = "D:/Git Projects/My Projects/PulseNex/PulseNexAPI/PulseNex/PulseNex/ConfigFiles/appsettings.json";
            }
            else
            {
                appSettingsLocation = "/app/ConfigFiles/appsettings.json";
            }
            return appSettingsLocation;
        }

        public static string GetLoginDataFileLocation()
        {
            string loginDataLocation = "";
            if (CommonHelper.IsDebug())
            {
                loginDataLocation = "D:/Git Projects/My Projects/PulseNex/PulseNexAPI/PulseNex/PulseNex/ConfigFiles/loginData.json";
            }
            else
            {
                loginDataLocation = "/app/ConfigFiles/loginData.json";
            }
            return loginDataLocation;
        }

        public static string GetSqLiteFileLocation()
        {
            string sqLiteFileLocation = "";
            if (CommonHelper.IsDebug())
            {
                sqLiteFileLocation = "D:/Git Projects/My Projects/PulseNex/PulseNexAPI/PulseNex/PulseNex/ConfigFiles/Database.db";
            }
            else
            {
                sqLiteFileLocation = "/app/ConfigFiles/Database.db";
            }
            return sqLiteFileLocation;
        }

        public static string GetFileFolderLocation()
        {
            string sqLiteFileLocation = "";
            if (CommonHelper.IsDebug())
            {
                sqLiteFileLocation = "D:/Git Projects/My Projects/PulseNex/PulseNexAPI/PulseNex/PulseNex/ConfigFiles/Files/";
            }
            else
            {
                sqLiteFileLocation = "/app/ConfigFiles/Files/";
            }
            return sqLiteFileLocation;
        }
    }
}
