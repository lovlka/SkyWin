using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SkyWin {
	[Serializable]
	public class Donation {
		public int ID {
			get;
			private set;
		}

		public int Value {
			get;
			set;
		}

		public DateTime DateTime {
			get;
			set;
		}

		private bool m_New = false;
		public Donation(Comit.New value) {
			m_New = true;
		}

		internal Donation(SqlDataReader dataReader) {
			Database.Bind(dataReader, this);
		}

		public void Save() {
			using(SqlConnection connection = new SqlConnection(Connection.Info)) {
				using(SqlCommand command = new SqlCommand()) {
					command.Connection = connection;
					command.Connection.Open();

					command.Parameters.Add("@Value", SqlDbType.Int).Value = Value;
					command.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = DateTime;

					if(m_New) {
						command.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
						command.CommandText = "INSERT INTO Donation(Value, DateTime) VALUES (@Value, @DateTime) SET @ID = @@Identity";
					}
					else {
						command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
						command.CommandText = "UPDATE Donation SET Value = @Value, DateTime = @DateTime WHERE ID = @ID";
					}
					command.ExecuteNonQuery();
					ID = Convert.ToInt32(command.Parameters["@ID"].Value);
					m_New = false;
				}
			}
		}

		public void Delete() {
			Delete(ID);
		}

		public static void Delete(int id) {
			using(SqlConnection connection = new SqlConnection(Connection.Info)) {
				using(SqlCommand command = new SqlCommand("DELETE FROM Donation WHERE ID = @ID", connection)) {
					command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					command.Connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}