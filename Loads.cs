using System.Collections.Generic;
using System.Data.OleDb;

namespace SkyWin
{
    public class Loads : List<Load>
    {
        public Loads()
        {
            using (var connection = new OleDbConnection(Connection.String))
            {
                using (var command = new OleDbCommand("SELECT * FROM Load", connection))
                {
                    command.Connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Add(new Load(dataReader));
                        }
                    }
                }
            }
        }
    }
}