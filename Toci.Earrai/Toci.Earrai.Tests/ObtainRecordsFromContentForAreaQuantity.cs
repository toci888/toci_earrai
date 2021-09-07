using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests
{
    public class ObtainRecordsFromContentForAreaQuantity
    {
        private List<string> workSheetNames;
        private List<DataForAreaQuantity> areaQuantityData;
        private Logic<Worksheetcontent> WorksheetContent = new Logic<Worksheetcontent>();
        private Logic<Area> Area = new Logic<Area>();
        private Logic<Codesdimension> CodesDimensions = new Logic<Codesdimension>();
        private Logic<Worksheet> WorkSheet = new Logic<Worksheet>();
        private Logic<Areaquantity> AreaQuantity = new Logic<Areaquantity>();

        public ObtainRecordsFromContentForAreaQuantity()
        {
            WorksheetContentCredentialsForAreaQuantity wsad = new WorksheetContentCredentialsForAreaQuantity();
            workSheetNames = wsad.workSheetNames;
            areaQuantityData = wsad.PrepareDataForAreaQuantity();
        }

        public void InsertAreaQuantity(AreaQuantityInsert wsad)
        {
            AreaQuantity.Insert(new Areaquantity
            {
                Idworksheet = wsad.idWorkSheet,
                Idcodesdimensions = wsad.idCodeDimension,
                Idarea = wsad.idArea,
                Iduser = 1,
                Rowindex = wsad.rowIndex,
                Quantity = wsad.quantity,
                Lengthdimensions = wsad.dimension,
                Createdat = DateTime.Now,
                Updatedat = DateTime.Now
            });
        }

        public void ObtainRecords()
        {
            var areas = Area.Select(m => true);
            var worksheetcontents = WorksheetContent.Select(m => true);
            var worksheets = WorkSheet.Select(m => true);
            var categories = CodesDimensions.Select(m => true);

            AreaQuantityInsert aqInsert = new AreaQuantityInsert();
            int catFlag = 0;

            foreach (var content in worksheetcontents)
            {
                catFlag = 0;
                string sheetName = "FLTS";
                int? idworksheet = content.Idworksheet;
                int idarea;

                /*
                //obtain sheetname
                foreach (var sheet in worksheets)
                {
                    if (sheet.Id == idworksheet)
                    {
                        sheetName = sheet.Sheetname;
                        break;
                    }
                }
                */

                //check in what range and sheet you are working with
                for (int j = 0; j < areaQuantityData.Count; j++)
                {
                    //now we have explicit range and sheet
                    if (areaQuantityData[j].shName.Equals(sheetName))
                    {
                        int columnIndex = (int)content.Columnindex;
                        int rowIndex = (int)content.Rowindex;
                        string value = content.Value;
                        string category = "";
             
                        if(rowIndex > 1 && rowIndex <= areaQuantityData[j].rowEnd && columnIndex == 0)
                        {             
                            category = value;
                            //check if category is not null -> make sure you are checking column 0!!
                            if(!String.IsNullOrEmpty(category))
                            {
                                aqInsert = new AreaQuantityInsert();
                                catFlag = 1;
                                //at this moment its clear we have category so now the process of obtaining data for the insert take a place
                                //it will work row after for and condition 'columnIndex == 0' makes sure it is the correct row
                                foreach(var cat in categories)
                                {
                                    //obtain category id
                                    if(cat.Code.Equals(value))
                                    {
                                        aqInsert.idCodeDimension = cat.Id;
                                        break;
                                    }
                                }
                                foreach(var sheet in worksheets)
                                {
                                    //obtain sheet id
                                    if(sheet.Sheetname.Equals(sheetName))
                                    {
                                        aqInsert.idWorkSheet = sheet.Id;
                                        break;
                                    }
                                }
                                aqInsert.rowIndex = rowIndex;
                            }
                        }
                        else if(aqInsert.idCodeDimension != null)
                        {
                            if (areaQuantityData[j].LengthColumn != -1)
                            {
                                if (columnIndex == areaQuantityData[j].LengthColumn)
                                {
                                    aqInsert.dimension = "" + value + " * ";
                                }
                                else if (columnIndex == areaQuantityData[j].WidthColumn)
                                {
                                    aqInsert.dimension += value;
                                }
                                else
                                {
                                    if (aqInsert.dimension != null)
                                    {
                                        for (int i = 0; i < areaQuantityData[j].AreaQuantityRanges.Count; i++)
                                        {
                                            var temp = areaQuantityData[j].AreaQuantityRanges;
                                            var l = temp[i].Length;
                                            var qty = temp[i][l - 2];
                                            var area = temp[i][l - 1];
                                            if(columnIndex == qty)
                                            {
                                                aqInsert.quantity = value;
                                                break;
                                            }
                                            else if(columnIndex == area)
                                            {
                                                if(value == null)
                                                {
                                                    catFlag = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    foreach(var ar in areas)
                                                    {
                                                        if(ar.Code.Equals(value))
                                                        {                                                     
                                                            aqInsert.idArea = ar.Id;
                                                            InsertAreaQuantity(aqInsert);
                                                            catFlag = 0;
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (catFlag == 0)
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < areaQuantityData[j].AreaQuantityRanges.Count; i++)
                                {
                                    var temp = areaQuantityData[j].AreaQuantityRanges;
                                    var l = temp[i].Length;
                                    var dim = temp[i][0];
                                    var qty = temp[i][l - 2];
                                    var area = temp[i][l - 1];
                                    if(columnIndex == dim)
                                    {
                                        aqInsert.dimension = value;
                                        break;
                                    }
                                    else if (columnIndex == qty)
                                    {
                                        aqInsert.quantity = value;
                                        break;
                                    }
                                    else if (columnIndex == area)
                                    {
                                        if (value == null)
                                        {
                                            InsertAreaQuantity(aqInsert);
                                            catFlag = 0;
                                            break;
                                        }
                                        else
                                        {
                                            foreach (var ar in areas)
                                            {
                                                if (ar.Code.Equals(value))
                                                {
                                                    aqInsert.idArea = ar.Id;
                                                    InsertAreaQuantity(aqInsert);
                                                    catFlag = 0;
                                                    break;
                                                }
                                            }
                                        }
                                        if (catFlag == 0)
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public class AreaQuantityInsert
        {
            public int idCodeDimension;
            public int idWorkSheet;
            public string dimension = null;
            public string quantity = null;
            public int idArea;
            public int rowIndex;
            public int idUser = 1;
        }
    }
}



