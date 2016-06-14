using CoachUs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUs.Models
{
    public static class LicensePackagePriceExtensions
    {
        public static LicensePackagePriceResponseModel ToModel(this LicensePackagePrice entity, LicensePackagePriceResponseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicensePackagePriceResponseModel();

            result = entity.ToBaseModel(result as LicensePackagePriceBaseModel) as LicensePackagePriceResponseModel;
            result.Id = entity.Id;
            result.CreatedDate = entity.CreatedDate;
            result.ModifiedDate = entity.ModifiedDate;

            return result;
        }

        public static ICollection<LicensePackagePriceResponseModel> ToModelList(this ICollection<LicensePackagePrice> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToModel()).ToList();
        }

        public static LicensePackagePriceBaseModel ToBaseModel(this LicensePackagePrice entity, LicensePackagePriceBaseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicensePackagePriceBaseModel();

            result.Months = entity.Months;
            result.Price = entity.Price;
            result.Active = entity.Active;

            return result;
        }

        public static ICollection<LicensePackagePriceBaseModel> ToBaseModelList(this ICollection<LicensePackagePrice> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToBaseModel()).ToList();
        }

        public static LicensePackagePrice ToEntity(this LicensePackagePriceBaseModel model, LicensePackagePrice result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePackagePrice();

            result.Months = model.Months;
            result.Price = model.Price;
            result.Active = model.Active;

            return result;
        }

        public static LicensePackagePrice ToEntity(this LicensePackagePriceCreateRequestModel model, LicensePackagePrice result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePackagePrice();

            result = (model as LicensePackagePriceBaseModel).ToEntity();
            result.LicensePackageId = model.LicensePackageId;

            return result;
        }

        public static LicensePackagePrice ToEntity(this LicensePackagePriceUpdateRequestModel model, LicensePackagePrice result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePackagePrice();

            result.Active = model.Active;

            return result;
        }
    }
}
