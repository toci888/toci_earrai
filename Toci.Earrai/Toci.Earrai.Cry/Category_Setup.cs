using System;
 using System.Collections.Generic;
using System.Text;
namespace Toci.Microsoft.Graph.Excel {
public class Category_Setup {
public CellData<string> Product_Code = new ("Product_Code", 0, 0 );
public CellData<string> Product_Description = new ("Product_Description", 0, 1 );
public CellData<string> CatDotNoDot = new ("CatDotNoDot", 0, 2 );
public CellData<string> Category = new ("Category", 0, 3 );
}
}
