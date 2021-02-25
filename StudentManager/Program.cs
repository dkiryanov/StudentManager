using System;
using System.Text;
using BLL.Models;
using BLL.Services;
using BLL.Services.Interfaces;
using StudentManager.IoC;

namespace StudentManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Запущен импорт информации об успеваемости студентов...");
            IImportService importerService = DependencyResolver.Resolve<IImportService>();

            ProcessImportInfoModel importInfo = importerService.ProcessImport();

            Console.WriteLine($"Файлов обработано: {importInfo.FilesCount}");

            foreach (var info in importInfo.Items)
            {
                Console.WriteLine($"Название курса: {info.Name}");
                Console.WriteLine($"Студентов добавлено: {info.Added}");
            }

            Console.WriteLine("Запущен экспорт информации об успеваемости студентов...");
            IExportService exportService = DependencyResolver.Resolve<IExportService>();
            exportService.ProcessExport();

            Console.WriteLine("Нажмите клавишу 'Пробел' для выхода...");
            Console.ReadKey();
        }
    }
}
