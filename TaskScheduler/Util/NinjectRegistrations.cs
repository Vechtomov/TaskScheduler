using TaskScheduler.Repository;
using Ninject.Modules;
using TaskScheduler.Repository.SqlRepository;

namespace TaskScheduler.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<SqlRepository>();
        }
    }
}