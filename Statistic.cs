using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Statistic {
		public int MemberNo {
			get;
			private set;
		}
		
		public string FirstName {
			get;
			private set;
		}

		public string LastName {
			get;
			private set;
		}

		public string NickName {
			get;
			private set;
		}

		public int Jumps {
			get;
			private set;
		}

		internal Statistic(OleDbDataReader dataReader) {
			Database.Bind(dataReader, this);
		}
	}
}