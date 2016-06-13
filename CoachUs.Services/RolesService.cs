using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Services;
using CoachUs.Data.Entities;
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
            return MainRepository.Get();
        }

        public IdentityRole GetRole(string name)
        {
            return MainRepository.Get(i => i.Name == name).SingleOrDefault();
        }
    }
}
