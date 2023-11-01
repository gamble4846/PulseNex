using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layers.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Layers.Controller
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
