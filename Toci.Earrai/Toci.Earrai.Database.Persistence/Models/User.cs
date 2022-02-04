using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class User
    {
        public User()
        {
            Areaquantities = new HashSet<Areaquantity>();
            Quoteandprices = new HashSet<Quoteandprice>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Emailconfirmed { get; set; }
        public string Token { get; set; }
        public int Idrole { get; set; }

        public virtual Role IdroleNavigation { get; set; }
        public virtual ICollection<Areaquantity> Areaquantities { get; set; }
        public virtual ICollection<Quoteandprice> Quoteandprices { get; set; }
    }
}
