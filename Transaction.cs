using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Transaction {
		public int AccountNo {
			get;
			private set;
		}
		
		public int TransNo {
			get;
			private set;
		}
		
		public string TransType {
			get;
			private set;
		}
		
		public string AccountType {
			get;
			private set;
		}

		public DateTime Regdate {
			get;
			private set;
		}

		public double Amount {
			get;
			private set;
		}

		public double Balance {
			get;
			private set;
		}

		public double Check {
			get;
			private set;
		}
		
		public string Comment {
			get;
			private set;
		}

		public DateTime FromDate {
			get;
			private set;
		}

		public DateTime ToDate {
			get;
			private set;
		}

		public int BoogieNo {
			get;
			private set;
		}

		public string Discount {
			get;
			private set;
		}

		public string PaymentType {
			get;
			private set;
		}

		public string Userid {
			get;
			private set;
		}

		public DateTime LastUpd {
			get;
			private set;
		}

		public int RelatedInternalNo {
			get;
			private set;
		}

		internal Transaction(OleDbDataReader dataReader) {
			Database.Bind(dataReader, this);
		}
	}
}