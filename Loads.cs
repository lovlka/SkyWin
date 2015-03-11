using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Loads : Comit.Collection<Load> {
		public Loads() {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand("SELECT * FROM Load", connection)) {
					command.Connection.Open();
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Add(new Load(dataReader));
						}
					}
				}
			}
		}
	}
}