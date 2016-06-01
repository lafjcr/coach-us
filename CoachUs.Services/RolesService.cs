using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace CoachUs.Services
{
    class RolesService : BaseService<IdentityRole>, IRolesService
    {
        public RolesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            return repository.Get();
        }

        public IdentityRole GetRole(string name)
        {
            return repository.Get(i => i.Name == name).SingleOrDefault();
        }
    }
}
