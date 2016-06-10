using CoachUs.Models;
using System.Collections.Generic;

namespace CoachUs.Services
{
    public interface ILicenseService
    {
        IEnumerable<LicenseResponseModel> GetLicenses();
        IEnumerable<LicenseGroupedResponseModel> GetGroupedLicenses();
        LicenseResponseModel GetLicense(int id);
        LicenseResponseModel AddLicense(LicenseCreateRequestModel model, IUsersService userService);
        void UpdateLicense(LicenseUpdateRequestModel model);
    }
}