using PulseNex.Model.Database_Models;

namespace PulseNex.DataAccess.Interface
{
    public interface ITbWidgetDataAccess
    {
        string Insert(tbWidgetInsertModel model);
        bool Update(tbWidgetUpdateModel model, Guid WidgetGUID);
        bool Delete(Guid WidgetGUID);
    }
}
