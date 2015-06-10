using CoachUs.WebAPI.Client;
using System.Web;
using System.Web.Mvc;

namespace CoachUs.App.Web
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        static string host = "http://localhost:36960/";

        private const string tokenKey = "accessToken";
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var token = httpContext.Request.Cookies[tokenKey];
            if (token == null)
                return false;

            var userInfo = Account.GetUserInfo(token.Value);

            if (! userInfo.HasRegistered)
                return false;

            // TODO: Verify user role

            SessionManager.User = userInfo.Email;
            //httpContext.Session["CoachUs-Role"] = userInfo.Email;

            return true;
            //return base.AuthorizeCore(httpContext);
        }
    }
}