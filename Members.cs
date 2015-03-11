using System.Collections.Generic;
using System.Data.OleDb;

namespace SkyWin
{
    public class Members : List<Member>
    {
        public Members(bool sinners = false)
        {
            using (var connection = new OleDbConnection(Connection.String))
            {
                using (var command = new OleDbCommand())
                {
                    command.CommandText = "SELECT * FROM Member ";

                    if (sinners)
                    {
                        command.CommandText += "WHERE Balance < 0 AND FirstName <> 'PAX' AND Lastname <> 'PAX' AND LicenseType <> 'E' ORDER BY Balance ASC";
                    }

                    command.Connection = connection;
                    command.Connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Add(new Member(dataReader));
                        }
                    }
                }
            }
        }
    }
}