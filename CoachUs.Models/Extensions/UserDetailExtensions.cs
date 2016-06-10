using CoachUs.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoachUs.Models
{
    public static class UserDetailExtensions
    {
        public static UserDetailModel ToModel(this UserDetail entity, UserDetailModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new UserDetailModel();

            result = entity.ToBaseModel(result as UserDetailBaseModel) as UserDetailModel;
            result.BirthDate = entity.BirthDate;
            result.Laterality = entity.LateralityValue;
            result.Address = entity.Address;

            return result;
        }

        public static ICollection<UserDetailModel> ToModelList(this ICollection<UserDetail> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToModel()).ToList();
        }

        public static UserDetailBaseModel ToBaseModel(this UserDetail entity, UserDetailBaseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new UserDetailBaseModel();

            result.UserId = entity.UserId;
            result.Name = entity.Name;
            result.LastName = entity.LastName;
            result.Gender = entity.GenderValue;
            result.Country = entity.Country;
            result.PhoneNumber = entity.User != null ? entity.User.PhoneNumber : result.PhoneNumber;

            return result;
        }

        public static ICollection<UserDetailBaseModel> ToBaseModelList(this ICollection<UserDetail> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToBaseModel()).ToList();
        }

        public static UserDetail ToEntity(this UserDetailModel model, UserDetail result = null)
        {
            if (model == null) return null;
            result = result ?? new UserDetail();

            result.UserId = result.UserId ?? model.UserId;
            result.Name = model.Name;
            result.LastName = model.LastName;
            result.BirthDate = model.BirthDate;
            result.GenderValue = model.Gender;
            result.LateralityValue = model.Laterality;
            result.Country = model.Country;
            result.Address = model.Address;

            return result;
        }


        public static UserDetailReferenceResponseModel ToReferenceModel(this UserDetail entity, UserDetailReferenceResponseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new UserDetailReferenceResponseModel();

            result.UserId = entity.UserId;
            result.Name = entity.Name;
            result.LastName = entity.LastName;
            result.Gender = entity.GenderValue;
            result.Country = entity.Country;
            result.Address = entity.Address;

            if (entity.User != null)
            {
                result.Email = entity.User.Email;
                result.PhoneNumber = entity.User.PhoneNumber;
            }

            return result;
        }

        public static ICollection<UserDetailReferenceResponseModel> ToReferenceModelList(this ICollection<UserDetail> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToReferenceModel()).ToList();
        }
    }
}
