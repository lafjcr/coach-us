using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    [RoutePrefix("Licenses")]
    public class LicensesController : CoachUsController
    {
        // GET: api/Licenses
        public IHttpActionResult Get(bool grouped = false)
        {
            try
            {
                if (grouped)
                {
                    var result = CoachUsServices.LicensesService.GetGroupedLicenses();
                    return Ok(result);
                }
                else
                {
                    var result = CoachUsServices.LicensesService.GetLicenses();
                    return Ok(result);
                }
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

        // GET: api/Licenses/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = CoachUsServices.LicensesService.GetLicense(id);
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

        // POST: api/Licenses
        public IHttpActionResult Post([FromBody]LicenseCreateRequestModel model)
        {
            try
            {
                var result = CoachUsServices.LicensesService.AddLicense(model, CoachUsServices.UsersService);
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
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Licenses/5
        public IHttpActionResult Put(int id, [FromBody]LicenseUpdateRequestModel model)
        {
            try
            {
                model.Id = id;
                CoachUsServices.LicensesService.UpdateLicense(model);
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

        // DELETE: api/Licenses/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CoachUsServices.LicensesService.DeleteLicense(id);
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

        // POST: api/Licenses/5/Pay
        [Route("~/api/Licenses/{id}/Pay")]
        public IHttpActionResult Pay(int id, [FromBody]LicensePaymentOrderPayModel model)
        {
            try
            {
                CoachUsServices.LicensesService.PayLicense(id, model);
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
            catch (InvalidOperationException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Licenses/5/ConfirmPayment/7
        [Route("~/api/Licenses/{id}/ConfirmPayment/{paymentId}")]
        public IHttpActionResult ConfirmPayment(int id, [FromUri]int paymentId)
        {
            try
            {
                CoachUsServices.LicensesService.ConfirmPayment(id, paymentId);
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
            catch (InvalidOperationException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Licenses/5/Renew
        [Route("~/api/Licenses/{id}/Renew")]
        public IHttpActionResult Renew(int id)
        {
            try
            {
                CoachUsServices.LicensesService.Renew(id);
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
            catch (InvalidOperationException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Licenses/5/ChangeLicense
        [Route("~/api/Licenses/{id}/ChangeLicense")]
        public IHttpActionResult ChangeLicense(int id, LicenseChangeRequestModel model)
        {
            try
            {
                model.Id = id;
                CoachUsServices.LicensesService.ChangeLicense(model);
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
            catch (InvalidOperationException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
