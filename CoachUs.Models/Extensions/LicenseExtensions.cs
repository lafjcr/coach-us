using CoachUs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUs.Models
{
    public static class LicenseExtensions
    {
        public static LicenseResponseModel ToModel(this License entity, LicenseResponseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicenseResponseModel();

            result = entity.ToBaseModel(result as LicenseBaseResponseModel) as LicenseResponseModel;
            result.Owner = entity.Owner.ToReferenceModel();

            return result;
        }

        public static ICollection<LicenseResponseModel> ToModelList(this ICollection<License> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToModel()).ToList();
        }

        public static LicenseBaseResponseModel ToBaseModel(this License entity, LicenseBaseResponseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicenseBaseResponseModel();

            result.Id = entity.Id;
            result.Active = entity.Active;
            result.CreatedDate = entity.CreatedDate;

            return result;
        }

        public static ICollection<LicenseBaseResponseModel> ToBaseModelList(this ICollection<License> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToBaseModel()).ToList();
        }

        public static ICollection<LicenseGroupedResponseModel> ToModelList(this IList<IGrouping<UserDetail, License>> entities)
        {
            if (entities == null) return null;
            var result = new List<LicenseGroupedResponseModel>();
            foreach (var entity in entities)
            {
                var item = new LicenseGroupedResponseModel()
                {
                    Owner = entity.Key.ToReferenceModel(),
                    Licenses = entity.ToList().ToBaseModelList()
                };
            }
            return entities.Select(item => new LicenseGroupedResponseModel() { Owner = item.Key.ToReferenceModel(), Licenses = item.ToList().ToBaseModelList() }).ToList();
        }

        public static License ToEntity(this LicenseCreateRequestModel model, License result = null)
        {
            if (model == null) return null;
            result = result ?? new License();

            result.OwnerId = model.OwnerId;
            result.Active = model.Active;

            return result;
        }

        public static License ToEntity(this LicenseUpdateRequestModel model, License result = null)
        {
            if (model == null) return null;
            result = result ?? new License();

            result.Active = model.Active;

            return result;
        }
    }
}
