using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.IdentityModel.Protocols;
using System.IO;
using System.Text.RegularExpressions;
using File = System.IO.File;

namespace Toci.Microsoft.Graph.Excel {
    public class EntityGenerator {
        
        private static List<string> generatedClass = new List<string>();

        private static int columnCounter = 0;
        
        public static void generateEntity(string tableName, string[] columns, int _rowOfEntityData, int _startCell, int _endCell)
        {

            getTopClass(tableName);

            for (int nowColumn = _startCell; nowColumn < _endCell; nowColumn++)
            {
                generateFields(columns[nowColumn], nowColumn, _rowOfEntityData);
            }

            generatedClassEnd();
            
            Console.WriteLine(generatedClass);

            File.WriteAllLines(@"C:\Users\tomek\source\repos\toci_earrai\Toci.Earrai\Toci.Earrai.Cry\"+ cleanStringForDatabase(tableName) + ".cs", generatedClass);

            resetCounter();

            resetList();

        }


        public static void getTopClass(string className) {
            // add namespace
            //generatedClass.Add(@" ");

            className = cleanStringForDatabase(className);

            generatedClass.Add("using System;\r\n using System.Collections.Generic;\r\nusing System.Text;");
            generatedClass.Add("namespace Toci.Microsoft.Graph.Excel {");
            generatedClass.Add("public class " + className + " {");
        }

        public static void generatedClassEnd() {
            generatedClass.Add("}");
            generatedClass.Add("}");
        }

        public static void generateFields(string field, int columnIndex, int rowIndex)
        {
            string tempField = field;
            tempField = cleanStringForDatabase(tempField);

            var isDouble = double.TryParse(field, out _);
            var isNumeric = int.TryParse(field, out _);// add double ;)

            string propTyle;
            if (isDouble) { propTyle = "double";
            } else if (isNumeric) { propTyle = "int";
            } else { propTyle = "string"; }

            if (tempField == "") {
                tempField = "column" + columnCounter++;
            }


            generatedClass.Add("public CellData<" + propTyle + "> " + tempField + " = new (\"" + tempField + "\", " + rowIndex + ", " + columnIndex + " );");
        }


        public static string cleanStringForDatabase(string value) 
        {

            value =  value.Replace(" ", "_")
                .Replace(".", "Dot")
                .Replace("+", "Plus")
                .Replace("£", "Pounds")
                .Replace("-", "Minus")
                .Replace("\n", "NewLine")
                .Replace("/", "Slash")
                .Replace("\\", "Slash")
                .Replace(",", "")
                .Replace("&", "And");
            
            if (Regex.IsMatch(value, @"^[0-9]") )
            {
                value = "_" + value;
            }

            return value;
        }

        public static string uncleanStringForExcel(string value) 
        {

            return value.Replace("_", "").Replace("Dot", ".").Replace("", ",").Replace("And", "&");
        }


        public static void resetCounter()
        {
            columnCounter = 0;
        }

        public static void resetList() 
        {
            generatedClass = new List<string>();
        }

    }
}
