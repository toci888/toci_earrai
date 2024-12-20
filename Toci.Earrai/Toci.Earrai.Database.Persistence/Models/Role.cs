﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Role
    {
        public Role()
        {
            Rolesactions = new HashSet<Rolesaction>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Rolesaction> Rolesactions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
