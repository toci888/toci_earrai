using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class UserLogic : Logic<User>, IUserLogic
    {
        public int CreateAccount(User user)
        {
            if (isLoginAlreadyInDb(user.Login))
            {
                return 0;
            }

            user.Password = HashPassword(user.Password);

            User newUser = Insert(user);

            return newUser.Id;
        }

        protected virtual bool isLoginAlreadyInDb(string login)
        {
            return Select(x => x.Login == login).Any();
        }

        private string HashPassword(string password)
        {
            var algorithm = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            foreach (var b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}