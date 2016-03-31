using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using System.IO;
using EnterpriseFrame.Service.Interface;
using EnterpriseFrame.Core.Data;
using EnterpriseFrame.EntityFramework;

namespace EnterpriseFrame.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterService();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        /// <summary>
        /// 使用Autofac注册服务
        /// </summary>
        private void RegisterService()
        {
            var builder = new ContainerBuilder();

           
            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var AllServices = assemblys
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

            builder.RegisterControllers(assemblys.ToArray());

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new EnterpriseContext("name=EnterpriseCon")).InstancePerLifetimeScope();//连接字符串

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));          
        }
    }
}
