using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Rolesaction
    {
        public int Id { get; set; }
        public int? Idaction { get; set; }
        public int? Idrole { get; set; }

        public virtual Action IdactionNavigation { get; set; }
        public virtual Role IdroleNavigation { get; set; }
    }
}
