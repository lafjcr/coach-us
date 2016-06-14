using CoachUs.Models;
using System.Collections.Generic;

namespace CoachUs.Services
{
    public interface ILicensePackagesService
    {
        IEnumerable<LicensePackageResponseModel> GetLicensePackages();
        LicensePackageResponseModel GetLicensePackage(int id);
        LicensePackageResponseModel AddLicensePackage(LicensePackageCreateRequestModel model);
        void UpdateLicensePackage(LicensePackageUpdateRequestModel model);
        void DeleteLicensePackage(int id);
    }
}