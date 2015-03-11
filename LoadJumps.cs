using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class LoadJumps : Comit.Collection<LoadJump> {
		public LoadJumps(int memberNo)
			: this(memberNo, DateTime.MinValue, default(int)) {
		}

		public LoadJumps(DateTime loadDate, int loadNo)
			: this(default(int), loadDate, loadNo) {
		}
		
		private LoadJumps(int memberNo, DateTime loadDate, int loadNo) {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand()) {
					string select = "SELECT Loadjump.*, Member.FirstName, Member.LastName, Typejumps.JumpTypeName ";
					string from = "FROM ((Loadjump LEFT JOIN Member ON Member.InternalNo = Loadjump.InternalNo) LEFT JOIN Typejumps ON Typejumps.JumpType = Loadjump.JumpType) ";
					string where = "";
					string order = "ORDER BY Loadjump.Regdate DESC, Loadjump.LoadNo DESC";
					
					if(memberNo != default(int)) {
						command.Parameters.Add("@MemberNo", OleDbType.Integer).Value = memberNo;
						where += "WHERE Member.MemberNo = @MemberNo ";
					}
					if(loadDate != DateTime.MinValue && loadNo != default(int)) {
						command.Parameters.Add("@Regdate", OleDbType.Date).Value = loadDate;
						command.Parameters.Add("@LoadNo", OleDbType.Integer).Value = loadNo;
						where += "WHERE Loadjump.Regdate = @Regdate AND Loadjump.LoadNo = @LoadNo ";
					}
					
					command.CommandText = select + from + where + order;
					command.Connection = connection;
					command.Connection.Open();
					
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Add(new LoadJump(dataReader));
						}
					}
				}
			}
		}
	}
}