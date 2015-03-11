using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace SkyWin {
	[Serializable]
	public class Donations : Comit.Collection<Donation> {
		public Donations(Comit.All value) {
			using(SqlConnection connection = new SqlConnection(Connection.Info)) {
				using(SqlCommand command = new SqlCommand("SELECT ID, Value, DateTime FROM Donation ORDER BY DateTime DESC", connection)) {
					command.Connection.Open();
					using(SqlDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Add(new Donation(dataReader));
						}
					}
				}
			}
		}

		public static int Value {
			get {
				using(SqlConnection connection = new SqlConnection(Connection.Info)) {
					using(SqlCommand command = new SqlCommand("SELECT ISNULL(SUM(Value), 0) FROM Donation", connection)) {
						command.Connection.Open();
						return Convert.ToInt32(command.ExecuteScalar());
					}
				}
			}
		}
	}
}
