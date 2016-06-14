using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace CoachUs.WebAPI.Controllers
{
    [RoutePrefix("LicensePackages")]
    public class LicensePackagesController : CoachUsController
    {
        // GET: api/LicensePackages
        public IHttpActionResult Get(bool includePrices = false)
        {
            try
            {
                if (includePrices)
                {
                    var result = CoachUsServices.LicensePackagesService.GetLicensePackages();
                    return Ok(result);
                }
                else
                {
                    var result = CoachUsServices.LicensePackagesService.GetLicensePackages();
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

        // GET: api/LicensePackages/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = CoachUsServices.LicensePackagesService.GetLicensePackage(id);
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

        // POST: api/LicensePackages
        public IHttpActionResult Post([FromBody]LicensePackageCreateRequestModel model)
        {
            try
            {
                var result = CoachUsServices.LicensePackagesService.AddLicensePackage(model);
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

        // PUT: api/LicensePackages/5
        public IHttpActionResult Put(int id, [FromBody]LicensePackageUpdateRequestModel model)
        {
            try
            {
                model.Id = id;
                CoachUsServices.LicensePackagesService.UpdateLicensePackage(model);
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

        // DELETE: api/LicensePackages/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CoachUsServices.LicensePackagesService.DeleteLicensePackage(id);
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
