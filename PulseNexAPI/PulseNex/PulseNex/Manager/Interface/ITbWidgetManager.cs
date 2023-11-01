using EasyCrudLibrary.Model;
using PulseNex.Model;
using PulseNex.Model.Database_Models;

namespace PulseNex.Manager.Interface
{
    public interface ITbWidgetManager
    {
        APIResponse Insert(tbWidgetInsertModel model);
        APIResponse Update(tbWidgetUpdateModel model, Guid WidgetGUID);
        APIResponse Delete(Guid WidgetGUID);
    }
}
