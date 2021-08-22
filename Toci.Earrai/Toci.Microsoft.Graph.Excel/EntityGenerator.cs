using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.IdentityModel.Protocols;
using System.IO;
using File = System.IO.File;

namespace Toci.Microsoft.Graph.Excel {
    public class EntityGenerator {

        private static GraphServiceClient graphClient;
        private int _rowOfEntityData;
        private int _startCell;
        private int _endCell;
        private string _worksheetName;
        private string _fileId;

        private List<string> generatedClass = new List<string>();

        public EntityGenerator(IAuthenticationProvider authProvider, int rowOfEntityData,
                int startCell, int endCell, string fileId, string worksheetName) {

            graphClient = new GraphServiceClient(authProvider);
            _rowOfEntityData = rowOfEntityData;
            _startCell = startCell;
            _endCell = endCell;
            _fileId = fileId;
            _worksheetName = worksheetName;

        }


        public void generateEntity()
        {

            string[] numOfPropertiesForEntity = new string[_endCell - _startCell];


            for (int nowCellColumn = _startCell; nowCellColumn < _endCell; nowCellColumn++) {

                var readSheet = graphClient.Me.Drive.Items[_fileId]
                        .Workbook.Worksheets[_worksheetName];

                var readTables = readSheet.Cell(_rowOfEntityData, nowCellColumn)
                    .Request().GetAsync().Result;

                var val = readTables.Values.RootElement.GetRawText();
                

                //var val2 = Newtonsoft.Json.Linq.JToken.Parse(val);

                numOfPropertiesForEntity[nowCellColumn] = val;
            }

            getTopClass("TableName");

            generateFields(numOfPropertiesForEntity);
            
            generatedClassEnd();
            Console.WriteLine(generatedClass);

            File.WriteAllLines("TestClass.cs", generatedClass);

            /*var x = new {
                "narz":
                {
                    "id": 4,
                        "name": "arek",
                            "created": "dzisiaj"
                }
            }*/


        }

        
        public void getTopClass(string className) {
            // add namespace
            //generatedClass.Add(@" ");


            generatedClass.Add("public class " + className + "{\r\n");
        }

        public void generatedClassEnd() {
            generatedClass.Add("}");
        }

        public void generateFields(string[] fields)
        {
            foreach (var field in fields)
            {
                var isNumeric = int.TryParse(field, out _);

                if (isNumeric)
                {
                    generatedClass.Add("private int " + field);
                }
                else
                {
                    generatedClass.Add("private string " + field);
                }
                
            }
        }

        
    }
}
