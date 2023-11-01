using Microsoft.AspNetCore.Mvc;
using PulseNex.ActionFilters;
using PulseNex.Manager.Interface;
using PulseNex.Model;
using PulseNex.Model.Database_Models;

namespace PulseNex.Controller
{
    [FullAuthorization]
    public class WidgetController : BaseController
    {
        ITbWidgetManager _tbWidgetManager { get; set; }
        public WidgetController(ITbWidgetManager tbWidgetManager)
        {
            _tbWidgetManager = tbWidgetManager;
        }

        [HttpPost]
        [Route("Widget/AddDefault")]
        public ActionResult AddDefault(tbWidgetInsertModel model)
        {
            try
            {
                return Ok(_tbWidgetManager.Insert(model));
            }
            catch(Exception ex) 
            {
                return Ok(new APIResponse(APIResponse.ResponseCode.ERROR,ex.Message,ex));
            }
        }

        [HttpPost]
        [Route("Widget/Update")]
        public ActionResult Update(tbWidgetUpdateModel model, Guid WidgetGUID)
        {
            try
            {
                return Ok(_tbWidgetManager.Update(model, WidgetGUID));
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse(APIResponse.ResponseCode.ERROR, ex.Message, ex));
            }
        }

        [HttpDelete]
        [Route("Widget/Delete")]
        public ActionResult Delete(Guid WidgetGUID)
        {
            try
            {
                return Ok(_tbWidgetManager.Delete(WidgetGUID));
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse(APIResponse.ResponseCode.ERROR, ex.Message, ex));
            }
        }
    }
}
