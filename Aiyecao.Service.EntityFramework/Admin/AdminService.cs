using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiyecao.Entity;
using Aiyecao.Core.Data;

namespace Aiyecao.Service.EntityFramework
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Admin> _adminRepository;
        public AdminService(IRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;

        }
        public bool CheckAdminPwd(string adminName, string adminPwd)
        {

            return _adminRepository.Table.Count(item => item.AdminName == adminName && item.AdminPwd == adminPwd) > 0;
            //return DbContextFactory.GetInstance().Admins.Count(item => item.AdminName == adminName && item.AdminPwd == adminPwd) > 0;
        }
    }
}
