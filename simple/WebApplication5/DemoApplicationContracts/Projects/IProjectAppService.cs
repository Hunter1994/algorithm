using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoApplicationContracts.Projects
{
    public interface IProjectAppService:IApplicationService
    {
        Task<string> Get();
        Task<string> GetListByPager(string pid);
    }
}
