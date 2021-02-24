using BLL.Factories;
using BLL.Services;
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
            Bind<IImporterService>().To<ImporterService>();
        }
    }
}