using Data.Models.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Base
{
    public interface IManagerService
    {
        Task<IEnumerable<ManagerViewModel>> FetchAsync();
    }
}
