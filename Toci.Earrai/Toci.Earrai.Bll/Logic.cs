using Microsoft.EntityFrameworkCore;
using Toci.Common.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class Logic<TModel> : LogicBase<TModel> where TModel : class
    {
        protected override DbContext GetEfHandle()
        {
            return new TociEarraiContext();
        }
    }
}