using EnterpriseFrame.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseFrame.Service.EntityFramework
{

    public interface IAdminService : IDependency
    {

        bool CheckAdminPwd(string adminName,string adminPwd);
        

    }
}
