using PulseNex.DataAccess.Interface;
using PulseNex.Manager.Interface;
using PulseNex.Model;
using PulseNex.Model.Database_Models;

namespace PulseNex.Manager.Impl
{
    public class TbWidgetManager : ITbWidgetManager
    {
        public ITbWidgetDataAccess _tbWidgetDataAccess { get; set; }
        public TbWidgetManager(ITbWidgetDataAccess tbWidgetDataAccess)
        {
            _tbWidgetDataAccess = tbWidgetDataAccess;
        }

        public APIResponse Insert(tbWidgetInsertModel model)
        {
            var newGuid = _tbWidgetDataAccess.Insert(model);
            if(String.IsNullOrEmpty(newGuid))
            {
                return new APIResponse(APIResponse.ResponseCode.ERROR, "Error Inserting Widget", model);
            }
            else
            {
                return new APIResponse(APIResponse.ResponseCode.SUCCESS, "Widget Added", newGuid);
            }
        }

        public APIResponse Update(tbWidgetUpdateModel model, Guid WidgetGUID)
        {
            var Updated = _tbWidgetDataAccess.Update(model, WidgetGUID);
            if (!Updated)
            {
                return new APIResponse(APIResponse.ResponseCode.ERROR, "Error Updating Widget", model);
            }
            else
            {
                return new APIResponse(APIResponse.ResponseCode.SUCCESS, "Widget Updated", WidgetGUID);
            }
        }

        public APIResponse Delete(Guid WidgetGUID)
        {
            var Deleted = _tbWidgetDataAccess.Delete(WidgetGUID);
            if (!Deleted)
            {
                return new APIResponse(APIResponse.ResponseCode.ERROR, "Error Deleting Widget", WidgetGUID);
            }
            else
            {
                return new APIResponse(APIResponse.ResponseCode.SUCCESS, "Widget Deleted", WidgetGUID);
            }
        }
    }
}
