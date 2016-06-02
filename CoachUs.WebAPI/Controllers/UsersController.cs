using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    //[CustomAuthorizeAttribute]
    [RoutePrefix("Users")]
    public class UsersController : CoachUsController
    {
        // GET: api/Users
        public IHttpActionResult Get()
        {
            try
            {
                var result = CoachUsServices.UsersService.GetUsers();
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(System.Net.HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Users/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var result = CoachUsServices.UsersService.GetUser(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(System.Net.HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]UserModel model)
        {
            try
            {
                var result = CoachUsServices.UsersService.AddUser(model);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(System.Net.HttpStatusCode.Unauthorized);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(string id, [FromBody]UserModel model)
        {
            try
            {
                model.Id = id;
                CoachUsServices.UsersService.UpdateUser(model);
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

        // DELETE: api/Users/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                CoachUsServices.UsersService.DeleteUser(id);
                return Ok();
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
    }
}
