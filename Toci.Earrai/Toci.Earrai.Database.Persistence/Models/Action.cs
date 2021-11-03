using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Action
    {
        public Action()
        {
            Rolesactions = new HashSet<Rolesaction>();
        }

        public int Id { get; set; }
        public string Action1 { get; set; }

        public virtual ICollection<Rolesaction> Rolesactions { get; set; }
    }
}
