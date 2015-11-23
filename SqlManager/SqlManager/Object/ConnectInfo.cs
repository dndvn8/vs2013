namespace SqlManager.Object
{
    public class ConnectInfo
    {
        public string ServerName { get;set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ConnectType { get; set; }

        public ConnectInfo(string serverName, string userName, string password, int connectType)
        {
            ServerName = serverName;
            UserName = userName;
            Password = password;
            ConnectType = connectType;
        }

        public string ConnectString
        {
            get
            {
                if (ConnectType == 0)
                    return "Data Source=" + ServerName + ";Integrated Security=True";
                return "Data Source=" + ServerName + ";Persist Security Info=True;User ID=" +
                       UserName + ";Password=" + Password;
            }
        }
    }
}
