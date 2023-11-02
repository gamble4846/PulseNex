using PulseNex.DataAccess.Interface;
using PulseNex.Helpers;
using PulseNex.Model.Database_Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PulseNex.DataAccess.Impl
{
    public class TbWidgetDataAccess : ITbWidgetDataAccess
    {
        public TbWidgetDataAccess()
        {

        }

        public string Insert(tbWidgetInsertModel model)
        {
            SqLiteHelper.CreateTableIfDoesNotExists("tbWidget");
            var con = SqLiteHelper.GetSqLiteConnection();
            var cmd = SqLiteHelper.GetSqliteCommand(con);
            var NewID = Guid.NewGuid().ToString();

            cmd.CommandText = "INSERT INTO tbWidget(GUIDWidget, Name, Color, ImageId) VALUES(@GUIDWidget,@Name,@Color,@ImageId)";
            cmd.Parameters.AddWithValue("@GUIDWidget", NewID);
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Color", model.Color);
            cmd.Parameters.AddWithValue("@ImageId", model.ImageId);

            var result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (result > 0)
                return NewID;
            return null;
        }

        public bool Update(tbWidgetUpdateModel model, Guid WidgetGUID) 
        {
            SqLiteHelper.CreateTableIfDoesNotExists("tbWidget");
            var con = SqLiteHelper.GetSqLiteConnection();
            var cmd = SqLiteHelper.GetSqliteCommand(con);

            cmd.CommandText = @"
                UPDATE tbWidget
                SET Name = @Name
                WHERE GUIDWidget = @GUIDWidget;
            ";

            cmd.Parameters.AddWithValue("@GUIDWidget", WidgetGUID.ToString());
            cmd.Parameters.AddWithValue("@Name", model.Name);

            var result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (result > 0)
                return true;
            return false;
        }

        public bool Delete(Guid WidgetGUID)
        {
            SqLiteHelper.CreateTableIfDoesNotExists("tbWidget");
            var con = SqLiteHelper.GetSqLiteConnection();
            var cmd = SqLiteHelper.GetSqliteCommand(con);

            cmd.CommandText = @"DELETE FROM tbWidget WHERE GUIDWidget = @GUIDWidget;";
            cmd.Parameters.AddWithValue("@GUIDWidget", WidgetGUID.ToString());

            var result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (result > 0)
                return true;
            return false;
        }
    }
}
