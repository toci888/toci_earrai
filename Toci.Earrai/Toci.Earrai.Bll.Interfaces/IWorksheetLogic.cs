using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IWorksheetLogic :  ILogicBase<Worksheet> 
    {
        Task<List<Worksheet>> GetAllWorksheets(string fileId);

        Task<List<object>> GetAllWorkbooks();
    }
}
