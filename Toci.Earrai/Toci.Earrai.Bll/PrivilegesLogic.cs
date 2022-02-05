using System.Linq;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class PrivilegesLogic : Logic<User>, IPrivilegesLogic
    {
        public User IncreasePrivileges(User user)
        {
            var u = Select(x => x.Email == user.Email && x.Firstname == user.Firstname && x.Lastname == user.Lastname).FirstOrDefault();

            if (u == null)
            {
                return null;
            }

            if (u.Idrole != (int)PrivilegesEnum.Admin)
            {
                u.Idrole++;
            }

            Update(u);

            return u;
        }

        public User DecreasePrivileges(User user)
        {
            var u = Select(x => x.Email == user.Email && x.Firstname == user.Firstname && x.Lastname == user.Lastname).FirstOrDefault();

            if (u == null)
            {
                return null;
            }

            if (u.Idrole != (int)PrivilegesEnum.User)
            {
                u.Idrole--;
            }

            Update(u);

            return u;
        }

        public User ChangePrivileges(User user, int privileges)
        {
            var u = Select(x => x.Email == user.Email && x.Firstname == user.Firstname && x.Lastname == user.Lastname).FirstOrDefault();

            if (u == null || privileges == null)
            {
                return null;
            }

            u.Idrole = privileges;

            Update(u);

            return u;
        }
    }
}