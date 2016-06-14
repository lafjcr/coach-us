using CoachUs.Models;
using System.Collections.Generic;

namespace CoachUs.Services
{
    public interface ILicensePackagePricesService
    {
        IEnumerable<LicensePackagePriceResponseModel> GetLicensePackagePrices(int licensePackageId);
        LicensePackagePriceResponseModel GetLicensePackagePrice(int id);
        LicensePackagePriceResponseModel AddLicensePackagePrice(LicensePackagePriceCreateRequestModel model);
        void UpdateLicensePackagePrice(LicensePackagePriceUpdateRequestModel model);
        void DeleteLicensePackagePrice(int id);
    }
}