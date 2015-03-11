using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data;

namespace SkyWin {
	public static class Database {
		internal static void Bind(IDataReader dataReader, object obj) {
			for(int i = 0; i < dataReader.FieldCount; i++) {
				if(!dataReader.IsDBNull(i)) {
					System.Reflection.PropertyInfo property = obj.GetType().GetProperty(dataReader.GetName(i));
					if(property != null) {
						property.SetValue(obj, dataReader.GetValue(i), null);
					}
				}
			}
		}
		
		public static bool IsValid(string path) {
			try {
				using(OleDbConnection connection = new OleDbConnection(Connection.GetConnectionString(path))) {
					using(OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM Member", connection)) {
						command.Connection.Open();
						if(Convert.ToInt32(command.ExecuteScalar()) > 0) {
							return true;
						}
					}
				}
			}
			catch {
			}
			return false;
		}
		
		public static string LastUpdatedInformation {
			get {
				DateTime lastUpdated = DateTime.MinValue;
				using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
					using(OleDbCommand command = new OleDbCommand("SELECT LastUpd FROM intdbinfo", connection)) {
						command.Connection.Open();
						lastUpdated = Convert.ToDateTime(command.ExecuteScalar());
					}
				}
				return String.Format("Informationen hämtas från SkyWin. Senast uppdaterad {0}.", lastUpdated.ToString("g"));
			}
		}
		
		private static string m_Path = String.Empty;
		public static string Path {
			get {
				if(String.IsNullOrEmpty(m_Path)) {
					m_Path = Comit.Configuration.Setting("SkyWinPath");
				}
				return m_Path;
			}			
		}
	}
}