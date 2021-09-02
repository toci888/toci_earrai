using System.Collections.Generic;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IWorksheetLogic : ILogicBase<Worksheet> 
    {
        Task<List<Worksheet>> GetAllWorksheets(string fileId);

        Task<List<object>> GetAllWorkbooks();

        List<Workbook> GetAllWorkbooksFromDb();

        public List<Worksheet> GetAllWorksheetsFromDb(string workbookId);
    }
}
