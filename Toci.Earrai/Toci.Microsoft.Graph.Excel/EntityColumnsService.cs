﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace Toci.Microsoft.Graph.Excel {
    public class EntityColumnsService
    {
        private static int offsetThreshold = 7;
        private static int offsetCounter = 0;

        public static string[] getColumnsFromWorksheet(IWorkbookWorksheetRequestBuilder graphClient,
            int _rowOfEntityData, int _startCell, int _endCell)
        {

            List<string> numOfPropertiesForEntityList = new List<string>();

            string[] numOfPropertiesForEntity = new string[_endCell - _startCell];



            int nowColumn = 0;
            do
            {
                var readTables = graphClient.Cell(_rowOfEntityData, nowColumn++)
                    .Request().GetAsync().Result;

                var val = readTables.Values.RootElement.GetRawText()
                                                            .Replace("[", "")
                                                            .Replace("]", "")
                                                            .Replace("\"", "");

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

            return numOfPropertiesForEntity;
            
        }

        
    }
}
