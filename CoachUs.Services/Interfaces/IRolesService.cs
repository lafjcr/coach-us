using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CoachUs.Services
{
    public interface IRolesService
    {
        IdentityRole GetRole(string name);
        IQueryable<IdentityRole> GetRoles();
    }
}