using FastMember;
using Microsoft.Data.Sqlite;

namespace PulseNex.Helpers
{
    public class SqLiteHelper
    {
        public SqLiteHelper()
        {

        }

        public static SqliteConnection GetSqLiteConnection()
        {
            var SqLiteFileLocation = CommonHelper.GetSqLiteFileLocation();
            SQLitePCL.Batteries.Init();
            SqliteConnection con = new SqliteConnection("Data Source=" + SqLiteFileLocation);
            con.Open();
            return con;
        }

        public static SqliteCommand GetSqliteCommand(SqliteConnection con) 
        {
            var cmd = new SqliteCommand("",con);
            return cmd;
        }

        public static void CreateTableIfDoesNotExists(string TableName)
        {
            var con = GetSqLiteConnection();
            var cmd = GetSqliteCommand(con);
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=@TableName;";
            cmd.Parameters.AddWithValue("@TableName", TableName);

            bool TableExists = false;
            using SqliteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TableExists = true;
            }

            if (TableExists)
                return;

            var cmd2 = GetSqliteCommand(con);
            cmd2.CommandText = GetDefaultCreateTableQuery(TableName);
            cmd2.ExecuteNonQuery();
            con.Close();
            return;
        }

        public static string GetDefaultCreateTableQuery(string TableName)
        {
            switch(TableName) 
            {
                case "tbWidget":
                    return @"CREATE TABLE tbWidget(GUIDWidget TEXT PRIMARY KEY,Name TEXT)";
                default:
                    throw new Exception("Table Name Not Found " + TableName);
            }
        }

        public static T ConvertSqliteToObject<T>(SqliteDataReader rd) where T : class, new()
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < rd.FieldCount; i++)
            {
                if (!rd.IsDBNull(i))
                {
                    string fieldName = rd.GetName(i);

                    if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldName] = rd.GetValue(i);
                    }
                }
            }

            return t;
        }
    }
}
