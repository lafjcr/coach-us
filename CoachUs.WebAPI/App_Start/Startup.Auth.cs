using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using CoachUs.WebAPI.Providers;
using CoachUs.WebAPI.Models;
using Microsoft.Owin.Security.Infrastructure;
using System.Threading.Tasks;

namespace CoachUs.WebAPI
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        /// <summary>
        /// This part has been added to have an API endpoint to authenticate users that accept a Facebook access token
        /// </summary>
        static Startup()
        {
            PublicClientId = "self";

            var expire = 10;
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                //Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/Account/ExternalLogin"),
                //AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(expire),
                RefreshTokenProvider = new ApplicationRefreshTokenProvider(expire),
                AllowInsecureHttp = true
            };

            // This is a key step of the solution as we need to supply a meaningful and fully working
            // implementation of the OAuthBearerOptions object when we configure the OAuth Bearer authentication mechanism. 
            // The trick here is to reuse the previously defined OAuthOptions object that already
            // implements almost everything we need
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions()
            {
                AccessTokenFormat = OAuthOptions.AccessTokenFormat,
                AccessTokenProvider = OAuthOptions.AccessTokenProvider,
                AuthenticationMode = OAuthOptions.AuthenticationMode,
                AuthenticationType = OAuthOptions.AuthenticationType,
                Description = OAuthOptions.Description,
                // The provider is the only object we need to redefine. See below for the implementation
                Provider = new CustomBearerAuthenticationProvider(),
                SystemClock = OAuthOptions.SystemClock
            };
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            //PublicClientId = "self";
            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"),
            //    Provider = new ApplicationOAuthProvider(PublicClientId),
            //    AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            //    AllowInsecureHttp = true
            //};

            // Enable the application to use bearer tokens to authenticate users
            //app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);
            OAuthBearerAuthenticationExtensions.UseOAuthBearerAuthentication(app, OAuthBearerOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }

    public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
    {
        private int _expire = 10;
        public ApplicationRefreshTokenProvider(int expire)
        {
            _expire = expire;
        }

        public override void Create(AuthenticationTokenCreateContext context)
        {
            // Expiration time in seconds
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(_expire));
            context.SetToken(context.SerializeTicket());
        }

        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }

    public class CustomBearerAuthenticationProvider : OAuthBearerAuthenticationProvider
    {
        // This validates the identity based on the issuer of the claim.
        // The issuer is set in the API endpoint that logs the user in
        public override Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            var claims = context.Ticket.Identity.Claims;
            var allowIssuers = new List<string> { "Facebook", "LOCAL_AUTHORITY", "LOCAL AUTHORITY" };
            foreach (var claim in context.Ticket.Identity.Claims)
            {                
                if (!allowIssuers.Contains(claim.Issuer))
                    context.Rejected();
            }
            return Task.FromResult<object>(null);
        }
    }
}
