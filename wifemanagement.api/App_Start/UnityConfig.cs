using System.Web.Http;
using Unity;
using Unity.WebApi;
using wmta.Repository;
using wmta.service;

namespace wifemanagement.api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IExpenseRepository, ExpenseService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}