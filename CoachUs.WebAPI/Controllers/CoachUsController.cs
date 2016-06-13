using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    [CustomAuthorizeAttribute]
    public abstract class CoachUsController : ApiController
    {
        Services.Services coachUsServices = null;

        protected Services.Services CoachUsServices
        {
            get
            {
                return coachUsServices ?? new Services.Services(User.Identity.GetUserId());
            }
        }

        protected override void Dispose(bool disposing)
        {
            CoachUsServices.Dispose();
            base.Dispose(disposing);
        }
    }
}
