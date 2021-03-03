using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BLL.DTO;
using BLL.Excel;
using BLL.Services.Interfaces;
using DAL.Entities.Students;
using DAL.UoW;
using OfficeOpenXml;

namespace BLL.Services
{
    public class ExcelService : IExcelService
    {
        private const int IndentIndex = 3;
        private const string PathToSaveXls = "../../../reports/report.xlsx";
        private const string PathToSavePdf = "../../../reports/report.pdf";
        private const string DefaultWorkSheetName = "Успеваемость";
        private const string AverageScoreDiagrammName = "Диаграмма средней успеваемости";
        private const string AverageScoreChartName = "Средняя успеваемость";
        private const string AverageScoreChartTitle = "Средняя успеваемость по студентам";

        private readonly IUnitOfWork _uow;
        private readonly IStudentCourseService _studentCourseService;
        private readonly IExcelManager _excelManager;
        private readonly IExcelToPdfReport _excelToPdfReport;

        public ExcelService(
            IUnitOfWork uow, 
            IStudentCourseService studentCourseService, 
            IExcelManager excelManager, 
            IExcelToPdfReport excelToPdfReport)
        {
            _uow = uow;
            _studentCourseService = studentCourseService;
            _excelManager = excelManager;
            _excelToPdfReport = excelToPdfReport;
        }

        public void Export()
        {
            IEnumerable<Course> courses = _uow
                .Students
                .Courses
                .GetAll(null, c => c.StudentCourses.Select(x => x.Student))
                .ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(DefaultWorkSheetName);

                int index = 1;
                foreach (Course course in courses)
                {
                    _excelManager.DisplayCourse(course, ws, index);
                    index += 3;
                }

                IEnumerable<StudentPerformanceDto> data = _studentCourseService.GetStudentPerformance();

                int maxRowCount = courses.Max(c => c.StudentCourses.Count);
                _excelManager.DisplayAverageScores(data, ws, maxRowCount + IndentIndex);
                DisplayAverageScoreDiagram(package, data);

                foreach (Course course in courses)
                {
                    DisplayCoursePerformanceDiagram(package, course);
                }

                package.SaveAs(new FileInfo(PathToSaveXls));

                Console.WriteLine("Экспорт в PDF запущен...");
                
                _excelToPdfReport.CreateExcelToPdfReport(PathToSaveXls, PathToSavePdf);
            }
        }

        public void DisplayAverageScoreDiagram(ExcelPackage package, IEnumerable<StudentPerformanceDto> data)
        {
            ExcelWorksheet worksheet = package
                .Workbook
                .Worksheets
                .Add(AverageScoreDiagrammName);

            _excelManager.DisplayAverageScores(data, worksheet);

            _excelManager.DisplayDiagram(
                worksheet,
                data.Count(),
                AverageScoreChartName,
                AverageScoreChartTitle);
        }

        public void DisplayCoursePerformanceDiagram(ExcelPackage package, Course course)
        {
            ExcelWorksheet worksheet = package
                .Workbook
                .Worksheets
                .Add($"{course.Name}: диаграмма успеваемости");

            _excelManager.DisplayCourse(course, worksheet);

            _excelManager.DisplayDiagram(
                worksheet,
                course.StudentCourses.ToList().Count,
                course.Name,
                $"{course.Name}: успеваемость по студентам");
        }
    }
}