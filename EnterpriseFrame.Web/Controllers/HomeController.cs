using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using EnterpriseFrame.Service;
using EnterpriseFrame.Service.EntityFramework;
using EnterpriseFrame.Core.Logging;
using System.Reflection;
using EnterpriseFrame.Core.Utility.ValidateCode;

namespace EnterpriseFrame.Web.Controllers
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
            string code;
            byte[] data = _validCode.CreateImage(out code);
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
            }
            _logger.WriteDebug(_validCode.GetType().Name+"验证码："+code);
            return File(data, @"image/jpeg");
        }
    }
}