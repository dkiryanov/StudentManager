namespace BLL.Excel
{
    public interface IExcelToPdfReport
    {
        void CreateExcelToPdfReport(string xlsPath, string pdfPath);
    }
}