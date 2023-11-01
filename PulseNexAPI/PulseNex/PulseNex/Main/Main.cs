using Newtonsoft.Json;
using PulseNex.Helpers;
using PulseNex.Model;

namespace PulseNex.Main
{
    public class MainClass
    {
        private static AppSettingsModel AppSettingsData { get; set; }
        public static void AddDependencies(IServiceCollection Service)
        {
            Service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        public static AppSettingsModel UpdateAppSettingsData()
        {
            AppSettingsModel model = new AppSettingsModel();
            var appSettingsLocation = CommonHelper.GetAppSettingsFileLocation();
            bool flag = File.Exists(appSettingsLocation);
            string contents = File.ReadAllText(appSettingsLocation);
            model = JsonConvert.DeserializeObject<AppSettingsModel>(contents);
            AppSettingsData = model;
            return model;
        }

        public static AppSettingsModel GetAppSettingsData()
        {
            return AppSettingsData;
        }
    }
}
