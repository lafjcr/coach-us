using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    [RoutePrefix("LicensePackagePrices")]
    public class LicensePackagePricesController : CoachUsController
    {
        // GET: api/LicensePackagePrices/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = CoachUsServices.LicensePackagePricesService.GetLicensePackagePrice(id);
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

        // POST: api/LicensePackagePrices
        public IHttpActionResult Post([FromBody]LicensePackagePriceCreateRequestModel model)
        {
            try
            {
                var result = CoachUsServices.LicensePackagePricesService.AddLicensePackagePrice(model);
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

        // PUT: api/LicensePackagePrices/5
        public IHttpActionResult Put(int id, [FromBody]LicensePackagePriceUpdateRequestModel model)
        {
            try
            {
                model.Id = id;
                CoachUsServices.LicensePackagePricesService.UpdateLicensePackagePrice(model);
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

        // DELETE: api/LicensePackagePrices/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CoachUsServices.LicensePackagePricesService.DeleteLicensePackagePrice(id);
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
