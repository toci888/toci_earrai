using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;

namespace Toci.Earrai.Tests.Import.Excel
{
    public class ExcelClient
    {
        protected GraphServiceClient graphClient;
        protected DeviceCodeAuthProvider authProvider;
        protected ImportManager impMan = new ImportManager();

        protected Dictionary<string, string> WorkbookMap = new Dictionary<string, string>()
        {
            //{ "PLT & SHEET", "A3:AF167" },
            { "Alum", "A3:U16" },
            /*{ "Msh & Exp.Metal", "A3:Y17" },
            { "Chan & Bms", "A3:R42" },
            { "Angles+T", "A3:AD86" },
            { "FLTS", "A3:V87" },
            { "Tube_CHS", "A3:AC61" },
            { "RHS", "A3:V61" },
            { "Rnds_Sqrs_HolBar", "A3:AD88" },*/
        };

        protected string fileId = "";

        public ExcelClient()
        {
            authProvider = new DeviceCodeAuthProvider();
            graphClient = new GraphServiceClient(authProvider);

            IDriveItemChildrenCollectionPage workbooks = graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;
            List<string> Ids = new List<string>();

            foreach (var workbookfile in workbooks)
            {
                Ids.Add(workbookfile.Id);
            }

            fileId = Ids[3];
        }

        public virtual Dictionary<string, WorkbookRange> RequestWorkbooks()
        {
            Dictionary<string, WorkbookRange> result = new Dictionary<string, WorkbookRange>();

            foreach (KeyValuePair<string, string> item in WorkbookMap)
            {
                var readSheet = graphClient.Me.Drive.Items[fileId].Workbook.Worksheets[item.Key];
                WorkbookRange range = readSheet.Range(item.Value).Request().GetAsync().Result;

                result.Add(item.Key, range);
            }

            impMan.EntireImport(result);

            return result;
        }

        public void hehe() {

        }
    }
}
