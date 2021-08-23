using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Microsoft.Graph.Excel {
    public class CellData<T>
    {
        private T columnName { get; set; } // te rozne typy maja tutaj sens?
        private int cellPositionIndex_X { get; set; }
        private int cellPositionIndex_Y { get; set; }

        public CellData(T _columnName, int _cellPositionIndex_X, int _cellPositionIndex_Y)
        {
            columnName = _columnName;
            cellPositionIndex_X = _cellPositionIndex_X;
            cellPositionIndex_Y = _cellPositionIndex_Y;
        }

    }


}
