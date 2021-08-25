using System;
 using System.Collections.Generic;
using System.Text;
namespace Toci.Microsoft.Graph.Excel {
public class OEM_Stock {
public CellData<string> Area = new ("Area", 0, 0 );
//public CellData<string> OEM_Stock = new ("OEM_Stock", 0, 1 );
public CellData<string> Qty = new ("Qty", 0, 2 );
public CellData<string> Unit_Cost_Pounds = new ("Unit_Cost_Pounds", 0, 3 );
public CellData<string> Total = new ("Total", 0, 4 );
}
}
