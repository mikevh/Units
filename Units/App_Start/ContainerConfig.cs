using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NLog;
using Units.Data;
using Units.Data.Models;

namespace Units.App_Start
{
    public class ContainerConfig
    {
        public static void SetupIOC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.Register(x => LogManager.GetCurrentClassLogger()).As<ILogger>();
            builder.RegisterType<UnitsDbContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<RedisCache>().As<ICacher>().SingleInstance();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<GradeRepo>().As<IGradeRepository>();
            builder.RegisterType<StudentRepo>().As<IStudentRepository>();
            builder.RegisterType<CourseRepo>().As<ICourseRepository>();
            builder.RegisterType<TodoRepo>().As<ITododRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
