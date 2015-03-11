using System;
using System.Data;
using System.Data.OleDb;

namespace SkyWin
{
    public static class Database
    {
        public static string LastUpdatedInformation
        {
            get
            {
                DateTime lastUpdated;
                using (var connection = new OleDbConnection(Connection.String))
                {
                    using (var command = new OleDbCommand("SELECT LastUpd FROM intdbinfo", connection))
                    {
                        command.Connection.Open();
                        lastUpdated = Convert.ToDateTime(command.ExecuteScalar());
                    }
                }
                return String.Format("Informationen hämtas från SkyWin. Senast uppdaterad {0}.", lastUpdated.ToString("g"));
            }
        }


        internal static void Bind(IDataReader dataReader, object obj)
        {
            for (var i = 0; i < dataReader.FieldCount; i++)
            {
                if (dataReader.IsDBNull(i)) continue;
                
                var property = obj.GetType().GetProperty(dataReader.GetName(i));
                if (property != null)
                    property.SetValue(obj, dataReader.GetValue(i), null);
            }
        }

        public static bool IsValid(string path)
        {
            try
            {
                using (var connection = new OleDbConnection(Connection.GetConnectionString(path)))
                {
                    using (var command = new OleDbCommand("SELECT COUNT(*) FROM Member", connection))
                    {
                        command.Connection.Open();
                        return Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}