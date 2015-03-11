using System;
using System.Configuration;

namespace SkyWin
{
    public static class Connection
    {
        private static string _path;
        private static string _string;

        public static string Path
        {
            get
            {
                if (String.IsNullOrEmpty(_path))
                    _path = ConfigurationManager.AppSettings.Get("SkyWinPath");

                return _path;
            }
        }

        public static string String
        {
            get
            {
                if (_string == null)
                    _string = GetConnectionString(Path);

                if (String.IsNullOrEmpty(_string))
                    throw new InvalidOperationException("SkyWin.Connection.String is not initialized.");
                
                return _string;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("SkyWin.Connection.String");
                
                if (value == String.Empty)
                    throw new ArgumentException("SkyWin.Connection.String must not be empty.");
                
                _string = value;
            }
        }

        internal static string GetConnectionString(string path)
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Persist Security Info=False;";
        }
    }
}