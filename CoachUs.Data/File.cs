//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoachUs.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class File
    {
        public File()
        {
            this.Teams = new HashSet<Team>();
            this.Users = new HashSet<User>();
            this.Events = new HashSet<Event>();
        }
    
        public int ID { get; set; }
        public string Path { get; set; }
        public string Thumbnail { get; set; }
    
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
