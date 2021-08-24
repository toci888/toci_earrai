using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Microsoft.Graph.Excel {
    public class CellData<T>
    {
        public string ColumnName { get; set; } 
        public T CellValue { get; set; }
        public  int cellPositionIndex_X { get; set; }
        public int cellPositionIndex_Y { get; set; }

        public CellData(string columnName, int _cellPositionIndex_X, int _cellPositionIndex_Y) //T cellValue, 
        {
            ColumnName = columnName;
           // CellValue = cellValue;
            cellPositionIndex_X = _cellPositionIndex_X;
            cellPositionIndex_Y = _cellPositionIndex_Y;
        }

    }


}
