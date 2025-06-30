using System.Web.Http;
using Unity;
using Unity.WebApi;
using TaskManagement.BLL.Interfaces;
using TaskManagement.BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using TaskManagement.DAL.Interfaces;
using TaskManagement.DAL.Repositories;

namespace TaskManagement.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register DAL Repositories
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProjectRepository, ProjectRepository>();

            // Register BLL Services
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IProjectService, ProjectService>();

            // Set Web API Dependency Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}


//using System.Web.Http;
//using Unity;
//using Unity.WebApi;

//namespace TaskManagement
//{
//    public static class UnityConfig
//    {
//        public static void RegisterComponents()
//        {
//			var container = new UnityContainer();

//            // register all your components with the container here
//            // it is NOT necessary to register your controllers

//            // e.g. container.RegisterType<ITestService, TestService>();

//            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
//        }
//    }
//}