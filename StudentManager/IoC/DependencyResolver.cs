using System.Reflection;
using Ninject;

namespace StudentManager.IoC
{
    public static class DependencyResolver
    {
        public static T Resolve<T>()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel.Get<T>();
        }
    }
}
