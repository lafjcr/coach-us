using CoachUs.Common.Data;
using CoachUs.Common.Enums;
using System;
using System.Collections.Generic;

namespace CoachUs.Data.Entities
{
    public class UserDetail// : IEntityBase
    {
        public UserDetail()
        {
            //this.AthletePlans = new HashSet<AthletePlan>();
            //this.CoachAthletePlans = new HashSet<AthletePlan>();
            //this.SharedAthletePlans = new HashSet<AthletePlan>();
            //this.Licenses = new HashSet<License>();
            //this.AuthorPlans = new HashSet<Plan>();
            //this.ModifierPlans = new HashSet<Plan>();
            //this.BuyerSales = new HashSet<Sale>();
            //this.SellerSales = new HashSet<Sale>();
            //this.Subscriptions = new HashSet<Subscription>();
            //this.CoahTeamPlans = new HashSet<TeamPlan>();
            //this.SharedTeamPlans = new HashSet<TeamPlan>();
            //this.OwnTeams = new HashSet<Team>();
            //this.Teams = new HashSet<TeamUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Laterality Laterality { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public Nullable<int> PictureID { get; set; }

        //public virtual ICollection<AthletePlan> AthletePlans { get; set; }
        //public virtual ICollection<AthletePlan> CoachAthletePlans { get; set; }
        //public virtual ICollection<AthletePlan> SharedAthletePlans { get; set; }
        //public virtual File Picture { get; set; }
        //public virtual ICollection<License> Licenses { get; set; }
        //public virtual ICollection<Plan> AuthorPlans { get; set; }
        //public virtual ICollection<Plan> ModifierPlans { get; set; }
        //public virtual ICollection<Sale> BuyerSales { get; set; }
        //public virtual ICollection<Sale> SellerSales { get; set; }
        //public virtual ICollection<Subscription> Subscriptions { get; set; }
        //public virtual ICollection<TeamPlan> CoahTeamPlans { get; set; }
        //public virtual ICollection<TeamPlan> SharedTeamPlans { get; set; }
        //public virtual ICollection<Team> OwnTeams { get; set; }
        //public virtual ICollection<TeamUser> Teams { get; set; }
    }
}
