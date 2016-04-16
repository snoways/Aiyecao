using Aiyecao.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiyecao.Service.EntityFramework
{

    public interface IAdminService : IDependency
    {

        bool CheckAdminPwd(string adminName,string adminPwd);
        

    }
}
