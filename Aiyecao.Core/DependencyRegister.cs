using Aiyecao.Core.Caching;
using EnterpriseFrame.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using Aiyecao.Core;
using System.Web;
namespace EnterpriseFrame.Core
{
    public class DependencyRegister : IDependencyRegister
    {
        public void Register(Autofac.ContainerBuilder builder)
        {
            builder.Register<IWebHelper>(c => new WebHelper(System.Web.HttpContext.Current.Request.RequestContext.HttpContext)).InstancePerLifetimeScope(); 
            builder.Register<Aiyecao.Core.Utility.ValidateCode.ValidateCodeType>(c => new Aiyecao.Core.Utility.ValidateCode.ValidateCode_Style3()).InstancePerLifetimeScope();//注册验证码
       
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
