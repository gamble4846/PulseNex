﻿using PulseNex.DataAccess.Interface;
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
            var con = SqLiteHelper.GetSqLiteConnection();
            var cmd = SqLiteHelper.GetSqliteCommand(con);
            var NewID = Guid.NewGuid().ToString();

            cmd.CommandText = "INSERT INTO tbWidget(GUIDWidget, Name) VALUES(@GUIDWidget,@Name)";
            cmd.Parameters.AddWithValue("@GUIDWidget", NewID);
            cmd.Parameters.AddWithValue("@Name", model.Name);

            var result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (result > 0)
                return NewID;
            return null;
        }

        public bool Update(tbWidgetUpdateModel model, Guid WidgetGUID) 
        {
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
    }
}