using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Toci.Earrai.Microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /*private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {












            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        internal async Task<String> CreateNewTextFileAsync() {
            Microsoft.Office365.SharePoint.FileServices.File newFile = new Microsoft.Office365.SharePoint.FileServices.File {

                ContentUrl = "https://gormleysengineering.sharepoint.com/:x:/r/3184Stock/_layouts/15/Doc.aspx?sourcedoc=%7BE0E677C6-7884-4E51-99D7-2595B5EABF13%7D&file=3184%20Gor_Product_Category_List%20LIVE.xlsx&action=default&mobileredirect=true"
            };


            Console.WriteLine(newFile);



            return "";



            try {

                // In this example, we'll create a simple text file and write the current timestamp into it. 
                string createdTime = "Created at " + DateTime.Now.ToLocalTime().ToString();

                using (MemoryStream stream = new MemoryStream(bytes)) {
                    // File is called demo.txt. If it already exists, we'll get an exception. 
                    Microsoft.Office365.SharePoint.FileServices.File newFile = new Microsoft.Office365.SharePoint.FileServices.File {
                        
                        ContentUrl = "https://gormleysengineering.sharepoint.com/:x:/r/3184Stock/_layouts/15/Doc.aspx?sourcedoc=%7BE0E677C6-7884-4E51-99D7-2595B5EABF13%7D&file=3184%20Gor_Product_Category_List%20LIVE.xlsx&action=default&mobileredirect=true"
                    };

                    // Create the empty file.
                    //await sharePointClient.Files.AddItemAsync(newFile);
                    //newID = newFile.Id;

                    // Upload the file contents.
                    //await sharePointClient.Files.GetById(newFile.Id).ToFile().UploadAsync(stream);
                }
            }

            // ODataErrorException can be thrown when you try to create a file that already exists.
            catch (Microsoft.Data.OData.ODataErrorException ex) {
                //isSuccess = false;
            }

            return newID;
        }


        public System.Data.DataTable ReadExcelFile(string fileName) {

            Microsoft.Office365.SharePoint.FileServices.File x = new Microsoft.Office365.SharePoint.FileServices.File()


            try {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url)) {
                    using (SPWeb web = site.OpenWeb()) {
                        SPFolder myLibrary = web.Folders["GatePassTemporaryDocuments"];

                        string fileExtension = Path.GetExtension(fileName).ToUpper();
                        string connectionString = "";

                        if (fileExtension == ".XLS") {
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + fileName + "'; Extended Properties='Excel 8.0;HDR=YES;'";
                        } else if (fileExtension == ".XLSX") {
                            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                        }
                        if (!(string.IsNullOrEmpty(connectionString))) {
                            string[] sheetNames = GetExcelSheetNames(connectionString);
                            if ((sheetNames != null) && (sheetNames.Length > 0)) {
                                System.Data.DataTable dt = null;
                                OleDbConnection con = new OLEDBConnection("sadasd");
                                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetNames[0] + "]", con);
                                dt = new System.Data.DataTable();
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            } catch (Exception ex) {


            }
            return null;

        }

        private string[] GetExcelSheetNames(string strConnection) {
            var connectionString = strConnection;
            String[] excelSheets;
            using (var connection = new OleDbConnection(connectionString)) {
                connection.Open();
                var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null) {
                    return null;
                }
                excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows) {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
            }
            return excelSheets;
        }*/
    }
}
