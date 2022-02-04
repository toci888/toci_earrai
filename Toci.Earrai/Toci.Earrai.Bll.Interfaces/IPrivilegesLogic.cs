using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IPrivilegesLogic : ILogicBase<User>
    {
        User ChangePrivileges(User user, int privileges);
        User IncreasePrivileges(User user);
        User DecreasePrivileges(User user);
    }
}