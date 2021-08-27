using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI.Interfaces
{
    public interface IApiConnector
    {
        public Task<Task<string>> GetAll();
    }
}