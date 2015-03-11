using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Statistics : Comit.Collection<Statistic> {
		private int m_Year;
		
		public Statistics(int year, int limit) {
			m_Year = year;
			
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand()) {
					string select = "SELECT " + (limit > 0 ? "TOP " + limit : "") + " Member.MemberNo, Member.FirstName, Member.LastName, Member.NickName, COUNT(*) AS Jumps ";
					string from = "FROM Loadjump LEFT JOIN Member ON Member.InternalNo = Loadjump.InternalNo ";
					string where = "WHERE Loadjump.Nostat = 'N' AND Loadjump.Regdate >= @StartDate AND Loadjump.Regdate <= @EndDate ";
					string group = "GROUP BY Member.MemberNo, Member.FirstName, Member.LastName, Member.NickName ";
					string order = "ORDER BY COUNT(*) DESC, Member.FirstName ASC, Member.LastName ASC";
					
					where += "AND Member.FirstName <> 'Pax' AND Member.LastName <> 'Pax' ";
				
					command.CommandText = select + from  + where + group + order;
					command.Parameters.Add("@StartDate", OleDbType.Date).Value = new DateTime(m_Year, 1, 1);
					command.Parameters.Add("@EndDate", OleDbType.Date).Value = new DateTime(m_Year, 12, 31);
					command.Connection = connection;
					command.Connection.Open();
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Add(new Statistic(dataReader));
						}
					}
				}
			}
		}
		
		private int? m_TotalJumps = null;
		public int TotalJumps {
			get {
				if(!m_TotalJumps.HasValue) {
					m_TotalJumps = GetCount(false);
				}
				return m_TotalJumps.Value - TandemJumps;
			}
		}

		private int? m_TandemJumps = null;
		public int TandemJumps {
			get {
				if(!m_TandemJumps.HasValue) {
					m_TandemJumps = GetCount(true);
				}
				return m_TandemJumps.Value;
			}
		}

		private int GetCount(bool tandem) {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand()) {
					string select = "SELECT COUNT(*) AS Jumps ";
					string from = "FROM Loadjump LEFT JOIN Member ON Member.InternalNo = Loadjump.InternalNo ";
					string where = "WHERE Loadjump.Nostat = 'N' AND Loadjump.Regdate >= @StartDate AND Loadjump.Regdate <= @EndDate ";

					if(tandem) {
						where += "AND Member.FirstName = 'Pax' AND Member.LastName = 'Pax' ";
					}
					else {
						where += "AND Member.FirstName <> 'Pax' AND Member.LastName <> 'Pax' ";
					}

					command.CommandText = select + from + where;
					command.Parameters.Add("@StartDate", OleDbType.Date).Value = new DateTime(m_Year, 1, 1);
					command.Parameters.Add("@EndDate", OleDbType.Date).Value = new DateTime(m_Year, 12, 31);
					command.Connection = connection;
					command.Connection.Open();
					
					return Convert.ToInt32(command.ExecuteScalar());
				}
			}
		}
	}
}