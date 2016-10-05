using CoachUs.Models;
using System.Collections.Generic;

namespace CoachUs.Services
{
    public interface ILicenseService
    {
        IEnumerable<LicenseResponseModel> GetLicenses();
        IEnumerable<LicenseGroupedResponseModel> GetGroupedLicenses();
        LicenseResponseModel GetLicense(int id);
        LicenseCreatedResponseModel AddLicense(LicenseCreateRequestModel model, IUsersService userService);
        void UpdateLicense(LicenseUpdateRequestModel model);
        void DeleteLicense(int id);
        void PayLicense(int id, LicensePaymentOrderPayModel model);
        void ConfirmPayment(int licensedId, int paymentId);
        void Renew(int id);
        void ChangeLicense(LicenseChangeRequestModel model);
    }
}