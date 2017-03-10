using ServantApply.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.IManagers
{
    public interface IUserManager
    {
        Task CreateAsync(User user);
    }
}
