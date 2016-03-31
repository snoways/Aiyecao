using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using EnterpriseFrame.Service;
using EnterpriseFrame.Service.Interface;

namespace EnterpriseFrame.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAdminService _adminService;
        public HomeController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public ActionResult Index()
        {
            var result = _adminService.CheckAdminPwd("admin", "123456");
            return Content(result.ToString());
        }
    }
}