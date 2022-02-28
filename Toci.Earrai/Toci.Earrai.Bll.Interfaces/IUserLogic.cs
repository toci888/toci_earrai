using System.Collections.Generic;
using System.Linq;
using Toci.Common.Bll;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IUserLogic : ILogicBase<Userrole>
    {
        public int CreateAccount(User user);
        public Userrole GenerateJwt(LoginDto user);
        public IEnumerable<User> GetAll();

        int ResetPassword(int userId, string password);
    }
}