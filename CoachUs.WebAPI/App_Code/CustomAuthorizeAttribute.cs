using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CoachUs.WebAPI
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        static string host = "http://localhost:36960/";

        private const string tokenKey = "Authorization";
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var token = httpContext.Request.Cookies[tokenKey];
        //    if (token == null)
        //        return false;

        //    //var userInfo = Account.GetUserInfo(token.Value);

        //    //if (! userInfo.HasRegistered)
        //        //return false;

        //    // TODO: Verify user role

        //    //SessionManager.User = userInfo.Email;
        //    //httpContext.Session["CoachUs-Role"] = userInfo.Email;

        //    return true;
        //    //return base.AuthorizeCore(httpContext);
        //}

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (AuthorizeRequest(actionContext))
            {
                return;
            }
            base.HandleUnauthorizedRequest(actionContext);
        }

        private bool AuthorizeRequest(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.GetValues(tokenKey);
            if (token == null)
                return false;

            return true;
        }
    }
}