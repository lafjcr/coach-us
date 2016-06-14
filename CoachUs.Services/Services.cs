using CoachUs.Common.Data.Infrastructure;
using CoachUs.Data;
using CoachUs.Data.Infrastructure;
using System;

namespace CoachUs.Services
{
    public class Services : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        IUsersService usersService = null;
        IRolesService rolesService = null;
        ILicenseService licensesService = null;
        ILicensePackagesService licensesPackagesService = null;
        ILicensePackagePricesService licensesPackagePricesService = null;

        readonly CallerUserInfo callerUserInfo;

        public Services(string userId)
        {
            var dbFactory = new DbFactory();
            unitOfWork = new UnitOfWork<CoachUsContext>(dbFactory);

            callerUserInfo = new CallerUserInfo(userId, RolesService);
        }

        public IUsersService UsersService
        {
            get
            {
                return usersService ?? new UsersService(callerUserInfo, unitOfWork);
            }
        }

        public IRolesService RolesService
        {
            get
            {
                return rolesService ?? new RolesService(unitOfWork);
            }
        }

        public ILicenseService LicensesService
        {
            get
            {
                return licensesService ?? new LicensesService(callerUserInfo, unitOfWork);
            }
        }

        public ILicensePackagesService LicensePackagesService
        {
            get
            {
                return licensesPackagesService ?? new LicensePackagesService(callerUserInfo, unitOfWork);
            }
        }

        public ILicensePackagePricesService LicensePackagePricesService
        {
            get
            {
                return licensesPackagePricesService ?? new LicensePackagePricesService(callerUserInfo, unitOfWork);
            }
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
