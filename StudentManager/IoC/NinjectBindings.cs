using BLL.Factories;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.UoW;
using Ninject.Modules;

namespace StudentManager.IoC
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();

            // Factories
            Bind<ICourseInfoUoWFactory>().To<CourseInfoUoWFactory>();

            // Services
            Bind<IFileService>().To<FileService>();
            Bind<IImportService>().To<ImportService>();
            Bind<IExportService>().To<ExportService>();
            Bind<IStudentService>().To<StudentService>();
            Bind<ICourseService>().To<CourseService>();
        }
    }
}