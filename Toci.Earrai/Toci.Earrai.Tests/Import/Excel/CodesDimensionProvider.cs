using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import.Excel
{
    public static class CodesDimensionProvider
    {
        private static Dictionary<string, Codesdimension> CodesDimensions = new Dictionary<string, Codesdimension>();

        public static Dictionary<string, Codesdimension> GetCodesDimensions()
        {
            return CodesDimensions;
        }

        static CodesDimensionProvider()
        {
            Logic<Codesdimension> CodesDimensionLogic = new Logic<Codesdimension>();

            IEnumerable<Codesdimension> categories = CodesDimensionLogic.Select(m => true);

            foreach (Codesdimension item in categories)
            {
                CodesDimensions.Add(item.Code, item);
            }
        }
    }
}