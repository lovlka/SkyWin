using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class LoadJump {
		public int BoogieNo {
			get;
			private set;
		}

		public DateTime Regdate {
			get;
			private set;
		}

		public string PlaneReg {
			get;
			private set;
		}

		public int LoadNo {
			get;
			private set;
		}

		public int JumpNo {
			get;
			private set;
		}

		public int GroupNo {
			get;
			private set;
		}

		public string Captain {
			get;
			private set;
		}

		public string Reported {
			get;
			private set;
		}

		public int InternalNo {
			get;
			private set;
		}

		public int Altitude {
			get;
			private set;
		}

		public string JumpType {
			get;
			private set;
		}

		public double Price {
			get;
			private set;
		}

		public double DiscountedPrice {
			get;
			private set;
		}

		public int StudentJumpNo {
			get;
			private set;
		}

		public string CanopyId {
			get;
			private set;
		}

		public double RentalAmount {
			get;
			private set;
		}

		public string Judgement {
			get;
			private set;
		}

		public double ExternalAmount {
			get;
			private set;
		}

		public double ExtraAmount {
			get;
			private set;
		}

		public string Comment {
			get;
			private set;
		}

		public int Weight {
			get;
			private set;
		}

		public int DebInternalNo {
			get;
			private set;
		}

		public int TransNo {
			get;
			private set;
		}

		public string Nostat {
			get;
			private set;
		}

		public int JumperFromGroupNo {
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

		public DateTime TimeForRequest {
			get;
			private set;
		}

		public DateTime TimeForInsert {
			get;
			private set;
		}

		public string VideoType {
			get;
			private set;
		}

		public string WingcamType {
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

		public string JumpTypeName {
			get;
			private set;
		}
		
		internal LoadJump(OleDbDataReader dataReader) {
			Database.Bind(dataReader, this);
		}
	}
}