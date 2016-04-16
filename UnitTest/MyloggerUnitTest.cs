using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aiyecao.Core.Logging;
using Autofac;

namespace UnitTest
{
    [TestClass]
    public class MyloggerUnitTest
    {
        [TestMethod]
        public void 日志测试()
        {
            ILogger my = new MyLogger("");
            my.WriteDebug("调试信息");
            my.WriteInfo("系统信息");
            my.WriteWarning("警告信息");
            my.WriteError("错误信息");
            my.WriteFatal("致命错误信息");

        }
        [TestMethod]
        public void 日志接口测试()
        {
            var build = new ContainerBuilder();
            build.Register<ILogger>(c => new MyLogger("")).InstancePerLifetimeScope();
            using (var container = build.Build())
            {
                ILogger logger = container.Resolve<ILogger>();
                logger.WriteError(new Exception("这是一个系统异常"));
                logger.WriteFatal(new Exception("这是一个致命的系统异常"));
            }
        }

    }
}
