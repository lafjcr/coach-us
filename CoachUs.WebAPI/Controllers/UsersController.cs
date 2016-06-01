using CoachUs.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    //[CustomAuthorizeAttribute]
    [RoutePrefix("Users")]
    public class UsersController : CoachUsController
    {
        // GET: api/Users
        public IEnumerable<UserModel> Get()
        {
            var result = CoachUsServices.UsersService.GetUsers();
            return result;
        }

        // GET: api/Users/5
        public IHttpActionResult Get(string id)
        {
            var result = CoachUsServices.UsersService.GetUser(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Users
        public UserModel Post([FromBody]UserModel model)
        {
            var result = CoachUsServices.UsersService.AddUser(model);
            return result;
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(string id, [FromBody]UserModel model)
        {
            CoachUsServices.UsersService.UpdateUser(id, model);
            return Ok();
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(string id)
        {
            CoachUsServices.UsersService.DeleteUser(id);
            return Ok();
        }
    }
}
