﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Emailconfirmed { get; set; }
        public int? Idrole { get; set; }

        public virtual Role IdroleNavigation { get; set; }
    }
}
