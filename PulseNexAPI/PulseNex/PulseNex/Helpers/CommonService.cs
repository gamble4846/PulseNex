using Newtonsoft.Json;
using PulseNex.Model;

namespace PulseNex.Helpers
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
    }
}
