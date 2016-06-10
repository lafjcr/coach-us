using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Data;
using CoachUs.Data.Entities;
using CoachUs.Data.Infrastructure;
using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachUs.Services
{
    public class Services
    {
        IUnitOfWork unitOfWork = null;
        IUsersService usersService = null;
        IRolesService rolesService = null;
        ILicenseService licensesService = null;

        readonly CallerUserInfo callerUserInfo;
        //UserModel CallerUser { get; set; }

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
    }
}
