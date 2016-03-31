﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseFrame.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Configuration;
using EnterpriseFrame.Service.EntityFramework;
using EnterpriseFrame.Service.Interface;
using EnterpriseFrame.Core.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EnterpriseContext db = new EnterpriseContext("name=EnterpriseCon");
            if (db.Admins.Count(item => item.AdminName == "haha" && item.AdminPwd == "123456") == 0)
                db.Admins.Add(new Admin() { AdminName = "haha", AdminPwd = "123456" });
            db.SaveChanges();
        }
        [TestMethod]
        public void Autofac注册方式一()
        {
            var build = new ContainerBuilder();
            build.RegisterType<AdminManager>();
            build.RegisterType<AdminService>().As<IAdminService>();

            build.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            build.Register<IDbContext>(c => new EnterpriseContext("name=EnterpriseCon")).InstancePerLifetimeScope();

            using (var container = build.Build())
            {
                var service = container.Resolve<AdminManager>();
                var result = service.CheckPwd("admin", "123456");
                Assert.IsTrue(result);

                var service2 = container.Resolve<IAdminService>();
                result=service2.CheckAdminPwd("admin", "123456");
                Assert.IsTrue(result);
            }

            //IAdminService service = new AdminService();
            //var result = service.CheckAdminPwd("admin", "123456");
            //Assert.IsTrue(result);
        }
        [TestMethod]
        public void Autofac注册方式二()//使用配置文件
        {
            var build = new ContainerBuilder();
            build.RegisterModule(new ConfigurationSettingsReader("autofac"));
            using (var container = build.Build())
            {
                var service = container.Resolve<IAdminService>();
                var result = service.CheckAdminPwd("admin", "123456");
                Assert.IsTrue(result);
            }
        }
    }
    public class AdminManager
    {
        private readonly IAdminService _adminService;
        public AdminManager(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public bool CheckPwd(string name,string pwd) 
        {
            return _adminService.CheckAdminPwd(name, pwd);
        }

    }
}
