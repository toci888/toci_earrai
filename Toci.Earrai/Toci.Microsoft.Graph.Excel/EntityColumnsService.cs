using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Graph;


// Workbook (wszystkie pliki)

// id nazwaPliku

// Wokrsheet ( sheety)

// id nazwa workbookReference


// Worksheets table

// ....          worksheetReference


namespace Toci.Microsoft.Graph.Excel {
    public class EntityColumnsService
    {
        private static int offsetThreshold = 7;
        private static int offsetCounter = 0;

        public virtual List<string> getColumnsFromWorksheet(IWorkbookWorksheetRequestBuilder graphClient,
            int _rowOfEntityData, int _startCell)
        {
            List<string> numOfPropertiesForEntityList = new List<string>();
            //string[] numOfPropertiesForEntity = new string[_endCell - _startCell];

            int nowColumn = 0;
            do
            {
                var readTables = graphClient.Cell(_rowOfEntityData, nowColumn++)
                    .Request().GetAsync().Result;

                var testRange = graphClient.Range("A1:Z230").Request().GetAsync().Result;
                JsonElement test2 = testRange.Values.RootElement;
                Console.WriteLine(testRange.Values.RootElement);

                var val = readTables.Values.RootElement.GetRawText()
                                                            .Replace("[", "")
                                                            .Replace("]", "")
                                                            .Replace("\"", "");

                TableTrimer tt = new TableTrimer();

                tt.trimExcelArray(test2);



                Console.WriteLine(val);
                Console.WriteLine(test2[0][2]);
                if (val == "")
                {
                    offsetCounter++;
                }
                else
                {
                    offsetCounter = 0;
                    numOfPropertiesForEntityList.Add(val);
                }

            } while (offsetCounter < offsetThreshold);
            

            /*for (int nowCellColumn = _startCell; nowCellColumn < _endCell; nowCellColumn++) {
                
                var readTables = graphClient.Cell(_rowOfEntityData, nowCellColumn)
                    .Request().GetAsync().Result;

                //var test = graphClient.Range("A1:E1").Request().GetAsync().Result;



                var val = readTables.Values.RootElement.GetRawText()
                                                        .Replace("[", "")
                                                        .Replace("]", "")
                                                        .Replace("\"", "");
                
                numOfPropertiesForEntity[nowCellColumn] = val;
            }*/

            return numOfPropertiesForEntityList;
            
        }

        
    }
}
