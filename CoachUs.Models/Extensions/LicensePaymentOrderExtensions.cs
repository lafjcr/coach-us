
using CoachUs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUs.Models
{
    public static class LicensePaymentOrderExtensions
    {
        public static LicensePaymentOrderResponseModel ToModel(this LicensePaymentOrder entity, LicensePaymentOrderResponseModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new LicensePaymentOrderResponseModel();

            result.Id = entity.Id;
            result.Owner = String.Format("{0} - {1} {2}", entity.License.Owner.User.UserName, entity.License.Owner.Name, entity.License.Owner.LastName);
            result.LicensePackage = String.Format("{0} {1} {2}", entity.LicensePackagePrice.LicensePackage.Name, entity.LicensePackagePrice.Months, entity.LicensePackagePrice.Months > 1 ? "meses" : "mes");
            result.Qty = entity.Qty;
            result.Users = entity.Users;
            result.UnitAmount = entity.UnitAmount;
            result.TotalAmount = entity.TotalAmount;
            result.PaidDate = entity.PaidDate;
            result.PaymentType = entity.PaymentTypeValue;
            result.PaymentReference = entity.PaymentReference;
            result.PaymentConfirmed = entity.PaymentConfirmed;
            result.CreatedDate = entity.CreatedDate;
            result.ModifiedDate = entity.ModifiedDate;

            return result;
        }

        public static ICollection<LicensePaymentOrderResponseModel> ToModelList(this ICollection<LicensePaymentOrder> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToModel()).ToList();
        }

        public static LicensePaymentOrder ToEntity(this LicensePaymentOrderPayModel model, LicensePaymentOrder result = null)
        {
            if (model == null) return null;
            result = result ?? new LicensePaymentOrder();

            result.PaymentTypeValue = model.PaymentType;
            result.PaymentReference = model.PaymentReference;

            return result;
        }
    }
}
