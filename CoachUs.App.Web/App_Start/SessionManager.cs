using System;
using System.Web.SessionState;

namespace CoachUs.App.Web
{
    public static class SessionManager
    {
        public static HttpSessionState Session { internal get; set; }
        
        public static string User
        {
            get { return Convert.ToString(Session[SessionConstants.User]); }
            set { Session[SessionConstants.User] = value; }
        }

        public static string Username
        {
            get { return User.Substring(0, User.IndexOf("@")); }            
        }

        public static string UserRole
        {
            get { return Convert.ToString(Session[SessionConstants.UserRole]); }
            set { Session[SessionConstants.UserRole] = value; }
        }

        private static class SessionConstants
        {
            public const string User = "User";
            public const string UserRole = "UserRole";
        }
    }
}