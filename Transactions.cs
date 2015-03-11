using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Transactions : Comit.Collection<Transaction> {
		public Transactions(int memberNo) {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand()) {
					string select = "SELECT Trans.*";
					string from = "FROM Trans LEFT JOIN Member ON Member.AccountNo = Trans.AccountNo ";
					string where = "WHERE Member.MemberNo = @MemberNo ";
					string order = "ORDER BY Trans.TransNo DESC";
					
					command.Parameters.Add("@MemberNo", OleDbType.Integer).Value = memberNo;
					command.CommandText = select + from + where + order;
					command.Connection = connection;
					command.Connection.Open();
					
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Add(new Transaction(dataReader));
						}
					}
				}
			}
		}
	}
}