using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Workbook = Toci.Earrai.Database.Persistence.Models.Workbook;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests
{
    public class SeedWorkBook
    {
        protected static Logic<Workbook> Workbooks = new Logic<Workbook>();
        protected static Logic<Worksheet> Worksheet = new Logic<Worksheet>();
        protected static Logic<Worksheetcontent> Worksheetcontent = new Logic<Worksheetcontent>();
        
        protected static Dictionary<string, List<string[]>> ExcelFilesAccessPoints = new Dictionary<string, List<string[]>>();

        private string fileId = "";
        private DeviceCodeAuthProvider authProvider;
        private GraphServiceClient graphClient;

        public SeedWorkBook()
        {
            authProvider = new DeviceCodeAuthProvider();
            graphClient = new GraphServiceClient(authProvider);
        }
        private void ObtainIdWorkBook()
        {
            var workbooks = graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;
            List<string> Ids = new List<string>();
            foreach (var workbookfile in workbooks)
            {
                Console.WriteLine(workbookfile.Name);
                Console.WriteLine(workbookfile.Id);
                Ids.Add(workbookfile.Id);
            }
            fileId = Ids[3];
        }

        public void SeedDBByWorkbook()
        {

            ObtainIdWorkBook();

            string[] wsadSheet1 = new string[3];
            string[] wsadSheet2 = new string[2];
            string[] wsadSheet3 = new string[2];
            string[] wsadSheet4 = new string[2];
            string[] wsadSheet5 = new string[2];
            string[] wsadSheet6 = new string[2];
            string[] wsadSheet7 = new string[2];
            string[] wsadSheet8 = new string[2];
            string[] wsadSheet9 = new string[2];
            string[] wsadSheet10 = new string[2];
            string[] wsadSheet11 = new string[2];
            string[] wsadSheet12 = new string[2];
            string[] wsadSheet13 = new string[2];

            wsadSheet1[0] = "Category Setup";
            wsadSheet1[1] = "A1:U65";
            wsadSheet1[2] = "GEng_Stock_2021-08-31_Standard_Items_LIVE_Retrieved_3-9-2021_18_41.xlsx";

            wsadSheet2[0] = "FinishProds";
            wsadSheet2[1] = "A1:R162";

            wsadSheet3[0] = "PLT & SHEET";
            wsadSheet3[1] = "A1:AF167";

            wsadSheet4[0] = "Alum";
            wsadSheet4[1] = "A1:U16";

            wsadSheet5[0] = "Msh & Exp.Metal";
            wsadSheet5[1] = "A1:Y17";

            wsadSheet6[0] = "Chan & Bms";
            wsadSheet6[1] = "A1:R42";

            wsadSheet7[0] = "Angles+T";
            wsadSheet7[1] = "A1:AD86";

            wsadSheet8[0] = "FLTS";
            wsadSheet8[1] = "A1:V87";

            wsadSheet9[0] = "Tube_CHS";
            wsadSheet9[1] = "A1:AC61";

            wsadSheet10[0] = "RHS";
            wsadSheet10[1] = "A1:V61";

            wsadSheet11[0] = "Rnds_Sqrs_HolBar";
            wsadSheet11[1] = "A1:AD88";

            wsadSheet12[0] = "Area List";
            wsadSheet12[1] = "A1:B27";

            wsadSheet13[0] = "Density";
            wsadSheet13[1] = "A1:E25";

            List<string[]> wsadSheets = new List<string[]>();
            wsadSheets.Add(wsadSheet1);
            wsadSheets.Add(wsadSheet2);
            wsadSheets.Add(wsadSheet3);
            wsadSheets.Add(wsadSheet4);
            wsadSheets.Add(wsadSheet5);
            wsadSheets.Add(wsadSheet6);
            wsadSheets.Add(wsadSheet7);
            wsadSheets.Add(wsadSheet8);
            wsadSheets.Add(wsadSheet9);
            wsadSheets.Add(wsadSheet10);
            wsadSheets.Add(wsadSheet11);
            wsadSheets.Add(wsadSheet12);
            wsadSheets.Add(wsadSheet13);

            ExcelFilesAccessPoints.Add(fileId, wsadSheets);

            foreach (KeyValuePair<string, List<string[]>> ele in ExcelFilesAccessPoints)
            {
                int counter = 0;
                Console.WriteLine("workbook" + ele.Value[0][2]);
                int idOfWorkbook = Workbooks.Insert(new Workbook()
                {
                    Idoffile = ele.Key,
                    Filename = ele.Value[0][2],
                    Createdat = DateTime.Now,
                    Updatedat = DateTime.Now
                }).Id;

                for (int ii = 0; ii < ele.Value.Count; ii++)
                {
                    Console.WriteLine("workbook" + ele.Value[ii][0]);
                    int idOfWorksheet = Worksheet.Insert(new Worksheet()
                    {
                        Idworkbook = idOfWorkbook,
                        Sheetname = ele.Value[ii][0],
                        Createdat = DateTime.Now,
                        Updatedat = DateTime.Now
                    }).Id;

                    var readSheet = graphClient.Me.Drive.Items[ele.Key].Workbook.Worksheets[ele.Value[ii][0]];
                    WorkbookRange testRange = readSheet.Range(ele.Value[ii][1]).Request().GetAsync().Result;
                    var bazka = testRange.Values.RootElement.ToString()
                        .Replace("[[", "")
                        .Split("],[").ToList();

                    int wsad = 0;

                    for (int i = 0; i < bazka.Count; i++)
                    {
                        var wierszJakoLista = bazka[i].Split(",").ToList();

                        for (int j = 0; j < wierszJakoLista.Count; j++)
                        {
                            Worksheetcontent.Insert(new Worksheetcontent()
                            {
                                Idworksheet = idOfWorksheet,
                                Rowindex = i,
                                Columnindex = j,
                                Value = wierszJakoLista[j].Replace("\"", "").Replace("\"", ""),
                                Createdat = DateTime.Now,
                                Updatedat = DateTime.Now
                            });
                            counter++;
                            wsad++;
                            if(wsad == 500)
                            {
                                wsad = 0;
                                Console.WriteLine("liczba insertow = " + counter);
                            }
                        }
                    }

                }
            }
        }


    }


}
