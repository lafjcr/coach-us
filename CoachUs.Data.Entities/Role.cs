using CoachUs.Common.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CoachUs.Data.Entities
{
    public class Role : IdentityRole, IEntityBase
    {
        int IEntityBase.Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
