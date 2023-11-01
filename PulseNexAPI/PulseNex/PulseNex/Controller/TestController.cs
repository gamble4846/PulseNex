using Microsoft.AspNetCore.Mvc;
using PulseNex.Helpers;

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
                return Ok(CommonService.GetAppSettings());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }
    }
}
