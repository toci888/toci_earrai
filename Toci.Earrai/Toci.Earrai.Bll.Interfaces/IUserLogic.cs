using Toci.Common.Bll;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IUserLogic : ILogicBase<User>
    {
        public int CreateAccount(User user);
    }
}