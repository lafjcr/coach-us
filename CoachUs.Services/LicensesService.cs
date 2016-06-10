using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Services;
using CoachUs.Data;
using CoachUs.Data.Entities;
using CoachUs.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

namespace CoachUs.Services
{
    class LicensesService : BaseService<License>, ILicenseService
    {
        readonly CallerUserInfo callerUserInfo;

        public LicensesService(CallerUserInfo callerUserInfo, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.callerUserInfo = callerUserInfo;
        }

        public IEnumerable<LicenseResponseModel> GetLicenses()
        {
            ICollection<LicenseResponseModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = repository.Get().ToList().ToModelList();
                var result2 = repository.Get().GroupBy(i => i.Owner).ToList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public IEnumerable<LicenseGroupedResponseModel> GetGroupedLicenses()
        {
            ICollection<LicenseGroupedResponseModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = repository.Get().GroupBy(i => i.Owner).ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicenseResponseModel GetLicense(int id)
        {
            LicenseResponseModel result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = repository.GetById(id).ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicenseResponseModel AddLicense(LicenseCreateRequestModel model, IUsersService userService)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var user = userService.GetUserDetails(model.OwnerId);
                if (user == null)
                    throw new ArgumentException("Invalid Owner Id");

                var entity = model.ToEntity();
                entity.CreatedDate = DateTime.UtcNow;

                entity = repository.Insert(entity);
                Commit();
                repository.LoadReference(entity, e => e.Owner);

                var result = entity.ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public void UpdateLicense(LicenseUpdateRequestModel model)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var entity = repository.GetById(model.Id);
                if (entity == null)
                    throw new ObjectNotFoundException();

                entity = model.ToEntity(entity);
                repository.Update(entity);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }
    }
}
