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
    
    public partial class ActivityCategory
    {
        public ActivityCategory()
        {
            this.Activities = new HashSet<Activity>();
            this.ActivityCategories1 = new HashSet<ActivityCategory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentActivityCategoryId { get; set; }
    
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ActivityCategory> ActivityCategories1 { get; set; }
        public virtual ActivityCategory ActivityCategory1 { get; set; }
    }
}
