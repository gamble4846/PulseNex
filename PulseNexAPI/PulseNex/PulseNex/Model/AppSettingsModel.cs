namespace PulseNex.Model
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
