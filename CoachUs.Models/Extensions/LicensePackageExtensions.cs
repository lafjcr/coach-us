using CoachUs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUs.Models
{
    public static class LicensePackageExtensions
    {
        public static LicensePackageResponseModel ToModel(this LicensePackage entity, LicensePackageResponseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicensePackageResponseModel();

            result = entity.ToBaseModel(result as LicensePackageBaseModel) as LicensePackageResponseModel;
            result.Id = entity.Id;
            result.CreatedDate = entity.CreatedDate;
            result.ModifiedDate = entity.ModifiedDate;

            return result;
        }

        public static ICollection<LicensePackageResponseModel> ToModelList(this ICollection<LicensePackage> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToModel()).ToList();
        }

        public static LicensePackageBaseModel ToBaseModel(this LicensePackage entity, LicensePackageBaseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicensePackageBaseModel();

            result.Name = entity.Name;
            result.Users = entity.Users;
            result.MinUsers = entity.MinUsers;
            result.MaxUsers = entity.MaxUsers;
            result.Active = entity.Active;

            return result;
        }

        public static ICollection<LicensePackageBaseModel> ToBaseModelList(this ICollection<LicensePackage> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToBaseModel()).ToList();
        }

        public static LicensePackage ToEntity(this LicensePackageBaseModel model, LicensePackage result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePackage();

            result.Name = model.Name;
            result.Users = model.Users;
            result.MinUsers = model.MinUsers;
            result.MaxUsers = model.MaxUsers;
            result.Active = model.Active;

            return result;
        }

        public static LicensePackage ToEntity(this LicensePackageCreateRequestModel model, LicensePackage result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePackage();

            result = (model as LicensePackageBaseModel).ToEntity();

            return result;
        }

        public static LicensePackage ToEntity(this LicensePackageUpdateRequestModel model, LicensePackage result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePackage();

            result.Active = model.Active;

            return result;
        }
    }
}
