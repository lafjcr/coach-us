using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using CoachUs.Data.Entities;

namespace CoachUs.Services
{
    public interface IRolesService
    {
        Role GetRole(string name);
        IQueryable<Role> GetRoles();
    }
}