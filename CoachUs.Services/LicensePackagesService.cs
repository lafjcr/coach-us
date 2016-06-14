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
    class LicensePackagesService : BaseService<LicensePackage>, ILicensePackagesService
    {
        readonly CallerUserInfo callerUserInfo;

        public LicensePackagesService(CallerUserInfo callerUserInfo, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.callerUserInfo = callerUserInfo;
            //AddRepository<LicensePackage>();
        }

        //EntityBaseRepository<LicensePackage> LicensePackageRepository
        //{
        //    get
        //    {
        //        return Repository<LicensePackage>();
        //    }
        //}

        public IEnumerable<LicensePackageResponseModel> GetLicensePackages()
        {
            ICollection<LicensePackageResponseModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.Get().ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicensePackageResponseModel GetLicensePackage(int id)
        {
            LicensePackageResponseModel result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.GetById(id).ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicensePackageResponseModel AddLicensePackage(LicensePackageCreateRequestModel model)
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

        public void UpdateLicensePackage(LicensePackageUpdateRequestModel model)
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

        public void DeleteLicensePackage(int id)
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
