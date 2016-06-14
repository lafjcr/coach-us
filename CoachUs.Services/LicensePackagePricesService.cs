using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Common.Data.Services;
using CoachUs.Data.Entities;
using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

namespace CoachUs.Services
{
    class LicensePackagePricesService : BaseService<LicensePackagePrice>, ILicensePackagePricesService
    {
        readonly CallerUserInfo callerUserInfo;

        public LicensePackagePricesService(CallerUserInfo callerUserInfo, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.callerUserInfo = callerUserInfo;
        }

        public IEnumerable<LicensePackagePriceResponseModel> GetLicensePackagePrices(int licensePackageId)
        {
            ICollection<LicensePackagePriceResponseModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.Get(i => i.LicensePackageId == licensePackageId).ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicensePackagePriceResponseModel GetLicensePackagePrice(int id)
        {
            LicensePackagePriceResponseModel result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.GetById(id).ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicensePackagePriceResponseModel AddLicensePackagePrice(LicensePackagePriceCreateRequestModel model)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var entity = model.ToEntity();
                entity.CreatedDate = entity.ModifiedDate = DateTime.UtcNow;

                entity = MainRepository.Insert(entity);
                Commit();

                var result = entity.ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public void UpdateLicensePackagePrice(LicensePackagePriceUpdateRequestModel model)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var entity = MainRepository.GetById(model.Id);
                if (entity == null)
                    throw new ObjectNotFoundException();

                entity = model.ToEntity(entity);
                entity.ModifiedDate = DateTime.UtcNow;

                MainRepository.Update(entity);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }

        public void DeleteLicensePackagePrice(int id)
        {
            if (callerUserInfo.IsAdmin)
            {
                var entity = MainRepository.GetById(id);
                if (entity == null)
                    throw new ObjectNotFoundException();
                MainRepository.Delete(entity);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }
    }
}
