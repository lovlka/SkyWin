using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Members : Comit.Collection<Member> {
		public Members()
			: this(false) {
		}

		public Members(bool sinners) {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand()) {
					command.CommandText = "SELECT * FROM Member ";

					if(sinners) {
						command.CommandText += "WHERE Balance < 0 AND FirstName <> 'PAX' AND Lastname <> 'PAX' AND LicenseType <> 'E' ORDER BY Balance ASC";
					}

					command.Connection = connection;
					command.Connection.Open();
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Add(new Member(dataReader));
						}
					}
				}
			}
		}
	}
}