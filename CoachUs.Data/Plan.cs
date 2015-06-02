//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoachUs.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan
    {
        public Plan()
        {
            this.Athletes = new HashSet<AthletePlan>();
            this.Teams = new HashSet<TeamPlan>();
            this.Trainings = new HashSet<Training>();
        }
    
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool IsTemplate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int LastModifierID { get; set; }
        public System.DateTime LastModifyDate { get; set; }
    
        public virtual ICollection<AthletePlan> Athletes { get; set; }
        public virtual User Author { get; set; }
        public virtual User LastModifier { get; set; }
        public virtual ICollection<TeamPlan> Teams { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
