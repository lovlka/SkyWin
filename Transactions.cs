using System.Collections.Generic;
using System.Data.OleDb;

namespace SkyWin
{
    public class Transactions : List<Transaction>
    {
        public Transactions(int memberNo)
        {
            using (var connection = new OleDbConnection(Connection.String))
            {
                using (var command = new OleDbCommand())
                {
                    const string select = "SELECT Trans.*";
                    const string from = "FROM Trans LEFT JOIN Member ON Member.AccountNo = Trans.AccountNo ";
                    const string where = "WHERE Member.MemberNo = @MemberNo ";
                    const string order = "ORDER BY Trans.TransNo DESC";

                    command.Parameters.Add("@MemberNo", OleDbType.Integer).Value = memberNo;
                    command.CommandText = select + from + where + order;
                    command.Connection = connection;
                    command.Connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Add(new Transaction(dataReader));
                        }
                    }
                }
            }
        }
    }
}