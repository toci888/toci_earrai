using System;
using Toci.Earrai.Tests;

namespace Toci.Earrai.Cry
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelSharepoint excelSharepoint = new ExcelSharepoint();

            excelSharepoint.AddInfoToExcel();

            Console.WriteLine("Hello World!");
        }
    }
}
