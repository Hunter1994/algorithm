using DemoApplicationContracts.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoApplication.Projects
{
    public class ProjectAppService : ApplicationService, IProjectAppService 
    {
        public async Task<string> Get()
        {
            return "1";
        }

        public async Task<string> GetListByPager(string pid)
        {
            return "2";
        }

    }
}
