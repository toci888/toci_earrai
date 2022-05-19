using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.SageIntegration
{
    public class SageExportLogic
    {
        public virtual List<List<string>> GetExportDataForProductDtos(List<ProductDto> productDtos)
        {
            List<List<string>> result = new List<List<string>>();

            result.Add(GenerateHeader());

            return result;
        }

        protected virtual List<string> GenerateHeader()
        {
            //todo
            string[] elements = "ProductRecord.AccountReference, ProductRecord.Description".Split(", ", StringSplitOptions.None);

            return elements.ToList();
        }
    }
}
