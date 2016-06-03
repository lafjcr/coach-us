using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachUs.Services
{
    class CallerUserInfo
    {
        public CallerUserInfo(string userId, IRolesService rolesService)
        {
            UserId = userId;
            this.rolesService = rolesService;
            IsAdmin = GetIsAdmin();
        }

        readonly IRolesService rolesService;

        public string UserId { get; private set; }

        public bool IsAdmin { get; private set; }        

        private bool GetIsAdmin()
        {
            var adminRole = rolesService.GetRole(RolesEnum.Admin.ToString());
            return adminRole.Users.Any(i => i.UserId == UserId);
        }
    }
}
