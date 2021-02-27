using System.Collections.Generic;
using BLL.DTO;
using DAL.Entities.Students;
using OfficeOpenXml;

namespace BLL.Excel
{
    public interface IExcelManager
    {
        void DisplayCourse(Course course, ExcelWorksheet ws, int index = 1);

        void DisplayAverageScores(IEnumerable<StudentPerformanceDto> studentPerformances, ExcelWorksheet ws, int startIndex = 1);

        void DisplayDiagram(ExcelWorksheet worksheet, int itemsCount, string chartName, string chartTitle);
    }
}
