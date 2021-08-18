using ClosedXML.Excel;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using DocumentFormat.OpenXml;
using System.Data.OleDb;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using Microsoft.SharePoint.Client;

namespace Toci.Earrai.Microservice.test {
    public class ExcelClient/* : IDisposable*/ {


        /*public ExcelClient(Uri webUri, ICredentials credentials) {
            WebUri = webUri;
            _client = new WebClient { Credentials = credentials };
        }*/

        /*static void DownloadFilesFromSharePoint(string siteUrl, string siteFolderPath, string localTempLocation) {

            string siteURL = ConfigurationManager.AppSettings["siteURL"];
            string userName = ConfigurationManager.AppSettings["userName"];
            string password = ConfigurationManager.AppSettings["password"];
            #region ConnectTo O365  
            //Create the client context object and set the credentials  
            ClientContext clientContext = new ClientContext(siteURL);
            SecureString securePassword = new SecureString();
            foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
            clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);

            var list = clientContext.Web.Lists.GetByTitle("Documents");
            var listItem = list.GetItemById(1);
            clientContext.Load(list);
            clientContext.Load(listItem, ii => ii.File);
            clientContext.ExecuteQuery();

            var fileRef = listItem.File.ServerRelativeUrl;
            var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var fileName = Path.Combine(path, (string)listItem.File.Name);
            using (var fileStream = System.IO.File.Create(fileName)) {
                fileInfo.Stream.CopyTo(fileStream);
            }

            var workbook = new XLWorkbook(path + "\\" + (string)listItem.File.Name);
            var ws = workbook.Worksheet(1);

            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "0", Text = "Other" });

            for (int num = startRow; num <= rowSize; num++) {
                selectList.Add(new SelectListItem { Value = ws.Row(num).Cell(ABC).GetValue<string>(), Text = ws.Row(num).Cell(customerName).GetValue<string>() });
            }
            if (System.IO.File.Exists(path + "\\" + (string)listItem.File.Name)) {
                System.IO.File.Delete(path + "\\" + (string)listItem.File.Name);
            }
            #endregion
            CompanyNameList = selectList;











            var clientContext3 = new ClientContext("https://sharpoint.url.com");
            string relativePath = "/folder/file.xls";
            clientContext3.Credentials = CredentialCache.DefaultCredentials;
            var file = clientContext3.Web.GetFileByServerRelativeUrl(relativePath);

            clientContext3.Load(file);
            clientContext3.ExecuteQuery();





            ClientContext ctx = new ClientContext(siteUrl);
            ctx.Credentials = new NetworkCredential("username", "password", "Domain");

            FileCollection files = ctx.Web.GetFolderByServerRelativeUrl(siteFolderPath).Files;

            ctx.Load(files);
            if (ctx.HasPendingRequest) {
                ctx.ExecuteQuery();
            }

            foreach (File file in files) {
                FileInformation fileInfo = File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
                ctx.ExecuteQuery();

                var filePath = localTempLocation + "\\" + file.Name;
                FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                fileInfo.Stream.CopyTo(fileStream);

            }
        }




        public DataTable FetchSheet(string ExcelFilePath, string SheetName) {

            SPHSite sPHSite = new SPHSite(ClientRuntimeContext);

            DataTable dt = new DataTable();
            try {
                string FrameNumbers = string.Empty;

                SPFile file = null;
                SPSecurity.RunWithElevatedPrivileges(delegate () {
                    file = SPContext.Current.Site.RootWeb.GetFile(ExcelFilePath);
                });

                using (Stream dataStream = file.OpenBinaryStream()) {
                    using (SpreadsheetDocument document = SpreadsheetDocument.Open(dataStream, false)) {
                        Workbook workbook = document.WorkbookPart.Workbook;

                        foreach (Sheet s in document.WorkbookPart.Workbook.Descendants<Sheet>()) {
                            if (s.Name.HasValue && s.Name.Value == SheetName) {
                                WorksheetPart wsPart = document.WorkbookPart.GetPartById(s.Id) as WorksheetPart;

                                if (wsPart == null) {
                                    continue;
                                }
                                IEnumerable<Row> rows = wsPart.Worksheet.Descendants<Row>();

                                foreach (Cell cell in rows.ElementAt(0)) {
                                    dt.Columns.Add(GetCellValue(cell));
                                }

                                int rowCount = 0;


                                foreach (Row row in rows) //this will also include your header row...
                                {
                                    if (rowCount != 0)//if this is not the first row i.e. column row                                     
                                    {
                                        //i=2 is Description column, i=8 is Expected return date column
                                        string itemDescription = GetCellValue(row.Descendants<Cell>().ElementAt(2));


                                        if (itemDescription.Trim() != "") {
                                            DataRow tempRow = dt.NewRow();
                                            for (int i = 0; i < row.Descendants<Cell>().Count(); i++) {
                                                tempRow[i] = GetCellValue(row.Descendants<Cell>().ElementAt(i));
                                            }
                                            dt.Rows.Add(tempRow);
                                        }

                                    }
                                    rowCount++;

                                }
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                logger.InsertLog("GatePassSystem", ex.ToString());
            }
            return dt;
        }



        public string ReadTable(string libraryName, string fileName, string tableName, string formatType) {

            ClientContext context = new ClientContext("");

            //context.Auth





            SPFile file = Web.GetFile("http://servername:1000/ExcelDocs//ExcelFile.xlsx");
            Stream dataStream = file.OpenBinaryStream();
            XLWorkbook workbook = new XLWorkbook(dataStream);




            var endpointUrl = string.Format("{0}/_vti_bin/ExcelRest.aspx/{1}/{2}/Model/Tables('{3}')?$format={4}", WebUri, libraryName, fileName, tableName, formatType);
            return _client.DownloadString(endpointUrl);
        }


        public void Dispose() {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }

        public Uri WebUri { get; private set; }

        private readonly WebClient _client;

    }*/
}
