using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SkyWin {
	[Serializable]
	public class Member {
		public int AccountNo {
			get;
			private set;
		}

		public string Address1 {
			get;
			private set;
		}

		public string Address2 {
			get;
			private set;
		}

		public DateTime AddressChangeDate {
			get;
			private set;
		}

		public double Balance {
			get;
			private set;
		}

		public string CertificateText {
			get;
			private set;
		}

		public string Club {
			get;
			private set;
		}

		public string Comment {
			get;
			private set;
		}

		public string ContactName {
			get;
			private set;
		}

		public string ContactPhone {
			get;
			private set;
		}

		public string CountryCode {
			get;
			private set;
		}

		public DateTime CreatedDate {
			get;
			private set;
		}

		public string Credit {
			get;
			private set;
		}

		public DateTime DateOfBirth {
			get;
			private set;
		}

		public string DisabledText {
			get;
			private set;
		}

		public DateTime EducatedDate {
			get;
			private set;
		}

		public string Education {
			get;
			private set;
		}

		public string Emailaddress {
			get;
			private set;
		}

		public string ExternalMemberNo {
			get;
			private set;
		}

		public DateTime FirstJumpDate {
			get;
			private set;
		}

		public string FirstName {
			get;
			private set;
		}

		public string Honorary {
			get;
			private set;
		}

		public string InfoViaEmail {
			get;
			private set;
		}

		public string InstructorText {
			get;
			private set;
		}

		public int InternalNo {
			get;
			private set;
		}

		public int JumpNo {
			get;
			private set;
		}

		public string LastName {
			get;
			private set;
		}

		public DateTime LastUpd {
			get;
			private set;
		}

		public string LicenseType {
			get;
			private set;
		}

		public string MarkedForLabel {
			get;
			private set;
		}

		public string MemberList {
			get;
			private set;
		}

		public string MemberListOverride {
			get;
			private set;
		}

		public int MemberNo {
			get;
			private set;
		}

		public string MemberType {
			get;
			private set;
		}

		public string NationalityCode {
			get;
			private set;
		}

		public string NickName {
			get;
			private set;
		}

		public string Occupation {
			get;
			private set;
		}

		public string PermanentCredit {
			get;
			private set;
		}

		public string PID {
			get;
			private set;
		}

		public string Pilot {
			get;
			private set;
		}

		public string Postcode {
			get;
			private set;
		}

		public string Posttown {
			get;
			private set;
		}

		public string Region {
			get;
			private set;
		}

		public DateTime RepackDate {
			get;
			private set;
		}

		public string Sex {
			get;
			private set;
		}

		public string State {
			get;
			private set;
		}

		public int StudentJumpNo {
			get;
			private set;
		}

		public string Supporter {
			get;
			private set;
		}

		public string Title {
			get;
			private set;
		}

		public string Userid {
			get;
			private set;
		}

		public int Weight {
			get;
			private set;
		}

		public string VerifiedLicense {
			get;
			private set;
		}

		public string Video {
			get;
			private set;
		}

		public int Year {
			get;
			private set;
		}
		
		private LoadJumps m_LoadJumps = null;
		public LoadJumps LoadJumps {
			get {
				if(m_LoadJumps == null) {
					m_LoadJumps = new LoadJumps(MemberNo);
				}
				return m_LoadJumps;
			}			
		}

		private Transactions m_Transactions = null;
		public Transactions Transactions {
			get {
				if(m_Transactions == null) {
					m_Transactions = new Transactions(MemberNo);
				}
				return m_Transactions;
			}
		}
		
		public Member(int memberNo) {
			using(OleDbConnection connection = new OleDbConnection(Connection.String)) {
				using(OleDbCommand command = new OleDbCommand("SELECT * FROM Member WHERE MemberNo = @MemberNo", connection)) {
					command.Parameters.Add("@MemberNo", OleDbType.Integer).Value = memberNo;
					command.Connection.Open();
					using(OleDbDataReader dataReader = command.ExecuteReader()) {
						if(dataReader.Read()) {
							Database.Bind(dataReader, this);
						}
					}
				}
			}
		}
		
		internal Member(OleDbDataReader dataReader) {
			Database.Bind(dataReader, this);
		}
	}
}