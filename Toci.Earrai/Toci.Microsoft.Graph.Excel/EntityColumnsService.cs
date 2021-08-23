using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace Toci.Microsoft.Graph.Excel {
    public class EntityColumnsService {

        public static string[] getColumnsFromWorksheet(IWorkbookWorksheetRequestBuilder graphClient,
            int _rowOfEntityData, int _startCell, int _endCell) {
            
            string[] numOfPropertiesForEntity = new string[_endCell - _startCell];

            for (int nowCellColumn = _startCell; nowCellColumn < _endCell; nowCellColumn++) {
                
                var readTables = graphClient.Cell(_rowOfEntityData, nowCellColumn)
                    .Request().GetAsync().Result;

                var val = readTables.Values.RootElement.GetRawText()
                                                        .Replace("[", "")
                                                        .Replace("]", "")
                                                        .Replace("\"", "");
                
                numOfPropertiesForEntity[nowCellColumn] = val;
            }

            return numOfPropertiesForEntity;
            
        }

        
    }
}
