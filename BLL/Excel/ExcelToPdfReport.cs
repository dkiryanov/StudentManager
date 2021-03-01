using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace BLL.Excel
{
    public class ExcelToPdfReport : IExcelToPdfReport
    {
        public void CreateExcelToPdfReport(string xlsPath, string pdfPath)
        {
            if (string.IsNullOrEmpty(xlsPath) || string.IsNullOrEmpty(pdfPath))
            {
                return;
            }

            string xlsFullPath = Path.GetFullPath(xlsPath);
            string pdfFullPath = Path.GetFullPath(pdfPath);

            Application excelApplication = new Application
            {
                ScreenUpdating = false,
                DisplayAlerts = false
            };

            Workbook excelWorkbook = excelApplication.Workbooks.Open(xlsFullPath);

            if (excelWorkbook == null)
            {
                excelApplication.Quit();
                excelApplication = null;
            }

            try
            {
                excelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, pdfFullPath);
            }
            finally
            {
                excelWorkbook.Close();
                excelApplication.Quit();
            }

            if (File.Exists(pdfFullPath))
            {
                Process.Start(pdfFullPath);
            }
        }
    }
}