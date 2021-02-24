using System;
using System.Text;
using BLL.Models;
using BLL.Services;
using StudentManager.IoC;

namespace StudentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Запущен импорт информации об успеваемости студентов...");
            IImporterService importerService = DependencyResolver.Resolve<IImporterService>();

            ProcessImportInfoModel importInfo = importerService.ProcessImport();

            Console.WriteLine($"Файлов обработано: {importInfo.FilesCount}");

            foreach (var info in importInfo.Items)
            {
                Console.WriteLine($"Название курса: {info.Name}");
                Console.WriteLine($"Студентов добавлено: {info.Added}");
                Console.WriteLine($"Студентов обновлено: {info.Updated}");
            }

            Console.WriteLine("Нажмите клавишу 'Пробел' для выхода...");
            Console.ReadKey();
        }
    }
}
