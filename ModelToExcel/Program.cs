using Microsoft.Office.Interop.Excel;
using ModelToExcel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace ModelToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveDate();
            Console.ReadLine();
        }

        private static void SaveDate()
        {
            var data = TestModel.GetData();
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {                 
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            // 1 is sheet no.
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "Name";
            int Row = 2;
            foreach (var item in data)
            {
                xlWorkSheet.Cells[Row, 1] = item.ID;
                xlWorkSheet.Cells[Row, 2] = item.Name;
                Row = Row + 1;
            }
             

            xlWorkBook.SaveAs("d:\\csharp-Excel.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            Console.WriteLine("Excel file created , you can find the file d:\\csharp-Excel.xls");
             
        }

    }
}
