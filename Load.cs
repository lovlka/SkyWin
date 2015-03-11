using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Load {
		public int BoogieNo {
			get;
			private set;
		}

		public string Call15min {
			get;
			private set;
		}
		
		public string Call30min {
			get;
			private set;
		}

		public string Comment {
			get;
			private set;
		}

		public int CycleNo {
			get;
			private set;
		}

		public DateTime DroppedAt {
			get;
			private set;
		}

		public DateTime LandedAt {
			get;
			private set;
		}

		public DateTime LastUpd {
			get;
			private set;
		}

		public DateTime LiftedAt {
			get;
			private set;
		}

		public int LoadNo {
			get;
			private set;
		}

		public int LoadStatus {
			get;
			private set;
		}

		public int LoadTime {
			get;
			private set;
		}

		public string Location {
			get;
			private set;
		}

		public int MaxPass {
			get;
			private set;
		}

		public int MaxWeight {
			get;
			private set;
		}

		public string Nostat {
			get;
			private set;
		}

		public string PlaneReg {
			get;
			private set;
		}

		public DateTime Regdate {
			get;
			private set;
		}

		public string Reported {
			get;
			private set;
		}

		public string Userid {
			get;
			private set;
		}

		private LoadJumps m_LoadJumps = null;
		public LoadJumps LoadJumps {
			get {
				if(m_LoadJumps == null) {
					m_LoadJumps = new LoadJumps(Regdate, LoadNo);
				}
				return m_LoadJumps;
			}
		}
		
		public Load(int loadNo) {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand("SELECT * FROM Load WHERE LoadNo = @LoadNo", connection)) {
					command.Parameters.Add("@LoadNo", OleDbType.Integer).Value = loadNo;
					command.Connection.Open();
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						while(dataReader.Read()) {
							Database.Bind(dataReader, this);
						}
					}
				}
			}
		}
		
		internal Load(OleDbDataReader dataReader) {
			Database.Bind(dataReader, this);
		}
	}
}