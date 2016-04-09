using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using EnterpriseFrame.Core.Caching;
using EnterpriseFrame.Core.Infrastructure;

namespace UnitTest
{
    [TestClass]
    public class CachingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var build = new ContainerBuilder();
            build.Register<ICacheManager>(c => new MemoryCacheManager()).InstancePerLifetimeScope();
            using (var container = build.Build())
            {
                ICacheManager cache = container.Resolve<ICacheManager>();
                string key = "ym_cache_test";
                string str = "哈哈";

                string str2 = cache.Get<string>(key);
                if (string.IsNullOrWhiteSpace(str2))
                    cache.Set(key, str, 60);
                str2 = cache.Get<string>(key);
                Assert.AreEqual(str, str2);
                cache.Remove(key);
                string str4 = cache.Get<string>(key);
                Assert.IsNull(str4);

                string str3 = cache.Get<string>(key, () => { return str; });
                Assert.AreEqual(str, str3);
                cache.Remove(key);
                string str5 = cache.Get<string>(key);
                Assert.IsNull(str5);//等价于下面这么这种写法

            }

        }

    }
}
