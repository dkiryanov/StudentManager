using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using DAL.Entities.Students;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace BLL.Excel
{
    public class ExcelManager : IExcelManager
    {
        private const int DefaultIndex = 1;
        private const int HeaderFirstRowIndex = 1;
        private const int HeaderSecondRowIndex = 2;
        private const string Surname = "Фамилия";
        private const string Score = "Оценка";
        private const string AverageScoreHeader = "Средний балл по студенту";
        private const string AverageScore = "Средний балл";
        private const string OverallAverageScore = "Общий средний балл";
        private const int RoundPrecision = 2;
        private const int FirstColumnCellIndex = 1;
        private const int SecondColumnCellIndex = 2;
        private const int ChartIndent = 4;
        private const int DiagramDefaultOffset = 0;
        private const int DiagramDefaultColumnOffset = 0;
        private const int DiagramDefaultColumnIndex = 0;
        private const int DefaultDiagramBarcharFontSize = 12;
        private const int DiagramHeightInPx = 300;
        private const int DiagramWidthInPx = 550;

        public void DisplayCourse(Course course, ExcelWorksheet ws, int index = 1)
        {
            // Course name cell
            CreateBoldCell(ws, HeaderFirstRowIndex, index, course?.Name);

            // Surname cell
            CreateCell(ws, HeaderSecondRowIndex, index, Surname);

            // Score cell
            CreateCell(ws, HeaderSecondRowIndex, index + 1, Score);

            IEnumerable<StudentCourse> studentCourses = course?.StudentCourses.ToList();

            int rowIndex = HeaderSecondRowIndex + 1;
            int columnIndex = index - 1;

            foreach (StudentCourse sc in studentCourses)
            {
                ws.Cells[rowIndex, ++columnIndex].Value = sc.Student.Name;
                ws.Cells[rowIndex, ++columnIndex].Value = sc.Score;

                columnIndex = index - 1;
                rowIndex++;
            }
        }

        public void DisplayAverageScores(IEnumerable<StudentPerformanceDto> studentPerformances, ExcelWorksheet ws, int startIndex = 1)
        {
            int averageScoreHeaderCellIndex = startIndex;
            CreateBoldCell(ws, averageScoreHeaderCellIndex, DefaultIndex, AverageScoreHeader);

            int surnameCellIndex = averageScoreHeaderCellIndex + 1;
            CreateCell(ws, surnameCellIndex, DefaultIndex, Surname);
            CreateCell(ws, surnameCellIndex, DefaultIndex + 1, AverageScore);
            //IEnumerable<StudentPerformanceDto> studentPerformanceDtos = _studentCourseService.GetStudentPerformance();

            int rowIndex = surnameCellIndex + 1;
            int columnIndex = DefaultIndex - 1;
            foreach (StudentPerformanceDto dto in studentPerformances)
            {
                ws.Cells[rowIndex, ++columnIndex].Value = dto.StudentName;
                ws.Cells[rowIndex, ++columnIndex].Value = Math.Round(dto.AverageScore, RoundPrecision);

                columnIndex = DefaultIndex - 1;
                rowIndex++;
            }

            // Create a cell to store an overall range heading
            CreateBoldCell(ws, rowIndex, ++columnIndex, OverallAverageScore);

            double overallAverage = studentPerformances.Average(x => x.AverageScore);

            // Create a cell to store an overall range value
            CreateBoldCell(ws, 
                rowIndex, 
                ++columnIndex, 
                Math.Round(overallAverage, RoundPrecision));
        }

        public void DisplayDiagram(ExcelWorksheet worksheet, int itemsCount, string chartName, string chartTitle)
        {
            int chartRowIndex = itemsCount + ChartIndent;
            ExcelChart barChart = worksheet.Drawings.AddChart(chartName, eChartType.ColumnClustered);
            barChart.SetPosition(chartRowIndex, DiagramDefaultOffset, DiagramDefaultColumnIndex, DiagramDefaultColumnOffset);
            barChart.Title.Text = chartTitle;
            barChart.Title.Font.Bold = true;
            barChart.Title.Font.Size = DefaultDiagramBarcharFontSize;
            barChart.SetSize(DiagramWidthInPx, DiagramHeightInPx);

            ExcelChartSerie serie = barChart
                .Series
                .Add(worksheet.Cells[HeaderSecondRowIndex + 1, SecondColumnCellIndex, itemsCount + HeaderSecondRowIndex, SecondColumnCellIndex], 
                     worksheet.Cells[HeaderSecondRowIndex + 1, FirstColumnCellIndex, itemsCount + HeaderSecondRowIndex, FirstColumnCellIndex]);
            ExcelBarChartSerie barSeries = (ExcelBarChartSerie)serie;
            barSeries.DataLabel.Font.Bold = true;
            barSeries.DataLabel.ShowValue = true;
            barSeries.DataLabel.ShowPercent = true;
            barSeries.DataLabel.ShowLeaderLines = true;
            barSeries.DataLabel.Separator = ";";

            barSeries.DataLabel.Position = eLabelPosition.InBase;
        }

        private ExcelRange CreateCell(ExcelWorksheet ws, int rowIndex, int columnIndex, object value)
        {
            ExcelRange cell = ws.Cells[rowIndex, columnIndex];
            cell.Value = value;
            cell.AutoFitColumns();

            return cell;
        }

        public ExcelRange CreateBoldCell(ExcelWorksheet ws, int rowIndex, int columnIndex, object value)
        {
            ExcelRange cell = CreateCell(ws, rowIndex, columnIndex, value);
            cell.Style.Font.Bold = true;

            return cell;
        }
    }
}