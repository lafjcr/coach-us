using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    [RoutePrefix("api/Users/{id}")]
    public class UserDetailsController : CoachUsController
    {
        // GET: api/Users/5/Detail
        [Route("Detail")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var result = CoachUsServices.UsersService.GetUserDetails(id);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(System.Net.HttpStatusCode.Unauthorized);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Users/5/Detail
        [Route("Detail")]
        public IHttpActionResult Post([FromBody]UserDetailModel model)
        {
            try
            {
                CoachUsServices.UsersService.SaveUserDetails(model);
                return Ok();
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(System.Net.HttpStatusCode.Unauthorized);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
