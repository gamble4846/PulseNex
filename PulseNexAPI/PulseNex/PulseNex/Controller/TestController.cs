using Microsoft.AspNetCore.Mvc;
using PulseNex.ActionFilters;
using PulseNex.Helpers;
using PulseNex.Main;

namespace PulseNex.Controller
{
    [FullAuthorization]
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
                SqLiteHelper.CreateTableIfDoesNotExists("tbWidget");
                return Ok(MainClass.GetAppSettingsData());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }
    }
}
