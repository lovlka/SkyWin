using System;

namespace SkyWin {
	public static class Connection {
		private static string m_Info;
		public static string Info {
			get {
				if(m_Info == null) {
					m_Info = Comit.Configuration.Setting("SkyWinConnection");
				}
				if(String.IsNullOrEmpty(m_Info)) {
					throw new InvalidOperationException("SkyWin.Connection.Info is not initialized.");
				}
				return m_Info;
			}
			set {
				if(value == null) {
					throw new ArgumentNullException("SkyWin.Connection.Info");
				}
				if(value == String.Empty) {
					throw new ArgumentException("SkyWin.Connection.Info must not be empty.");
				}
				m_Info = value;
			}
		}

		private static string m_String;
		public static string String {
			get {
				if(m_String == null) {
					m_String = GetConnectionString(Database.Path);
				}
				if(String.IsNullOrEmpty(m_String)) {
					throw new InvalidOperationException("SkyWin.Connection.String is not initialized.");
				}
				return m_String;
			}
			set {
				if(value == null) {
					throw new ArgumentNullException("SkyWin.Connection.String");
				}
				if(value == String.Empty) {
					throw new ArgumentException("SkyWin.Connection.String must not be empty.");
				}
				m_String = value;
			}
		}
		
		internal static string GetConnectionString(string path) {
			return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Persist Security Info=False;";
		}
	}
}