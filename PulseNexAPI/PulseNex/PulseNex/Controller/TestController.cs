using Microsoft.AspNetCore.Mvc;
using PulseNex.Helpers;
using PulseNex.Main;

namespace PulseNex.Controller
{
    public class TestController : BaseController
    {
        public TestController()
        {
        }

        [HttpGet]
        [Route("TestAction")]
        public ActionResult TestAction()
        {
            try
            {
                return Ok(MainClass.GetAppSettingsData());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }
    }
}
