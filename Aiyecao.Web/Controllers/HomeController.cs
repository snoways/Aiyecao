using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Aiyecao.Service;
using Aiyecao.Service.EntityFramework;
using Aiyecao.Core.Logging;
using System.Reflection;
using Aiyecao.Core.Utility.ValidateCode;
using Aiyecao.Core.Infrastructure;
using EnterpriseFrame.Core.Infrastructure;


namespace Aiyecao.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;
        private ValidateCodeType _validCode;
        public HomeController(ILogger logger, ValidateCodeType validCode)
        {
            _validCode = validCode;
            _logger = logger;
        }
        public ActionResult Index()
        {
            var count = EngineContext.Current.ComponentRegistry.Registrations.Count();
            return Content("注册服务：" + count);
            //return ValidCode();
        }
        public ActionResult ValidCode()
        {
            string code;
            byte[] data = _validCode.CreateImage(out code);
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
            }
            _logger.WriteDebug(_validCode.GetType().Name + "验证码：" + code);
            return File(data, @"image/jpeg");
        }
    }
}