using EnterpriseFrame.Service.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{

    public class AdminManager
    {
        private readonly IAdminService _adminService;
        public AdminManager(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public bool CheckPwd(string name, string pwd)
        {
            return _adminService.CheckAdminPwd(name, pwd);
        }

    }
}
