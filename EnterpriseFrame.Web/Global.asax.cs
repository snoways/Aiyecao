﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using System.IO;
using EnterpriseFrame.Core.Data;
using EnterpriseFrame.Entity;
using EnterpriseFrame.Core.Infrastructure;
using EnterpriseFrame.Core.Logging;

namespace EnterpriseFrame.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new MyLogger(HttpContext.Current.Server.MapPath("")).WriteInfo("初始化开始");
            AreaRegistration.RegisterAllAreas();

            AutofacRegisterAll();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            new MyLogger(HttpContext.Current.Server.MapPath("")).WriteInfo("初始化完成");
        }
        #region 使用Autofac注册控制器/服务
        private void AutofacRegisterAll()
        {
            var builder = new ContainerBuilder();
            AutofacRegisterController(builder);
            AutofacRegisterService(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        private void AutofacRegisterController(ContainerBuilder builder)
        {
            var baseType = typeof(IDependency);
            //var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var assemblys = System.Web.Compilation.BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            var AllServices = assemblys
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

            builder.RegisterControllers(assemblys.ToArray());

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
        private void AutofacRegisterService(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new EnterpriseContext("name=EnterpriseCon")).InstancePerLifetimeScope();//连接字符串
            builder.Register<ILogger>(c => new MyLogger(HttpContext.Current.Server.MapPath(""))).InstancePerLifetimeScope();//注册日志 保存至根目录

            builder.Register<EnterpriseFrame.Core.Utility.ValidateCode.ValidateCodeType>(c => new EnterpriseFrame.Core.Utility.ValidateCode.ValidateCode_Style1()).InstancePerLifetimeScope();//注册日志 保存至根目录
        }
        #endregion
    }
}
