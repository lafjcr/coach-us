﻿using CoachUs.Common.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CoachUs.Data.Entities
{
    public class User : IdentityUser, IEntityBase
    {
        public virtual UserDetail UserDetail { get; set; }

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
