﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace DemoApplicationContracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    public class DemoApplicationContractsModule:AbpModule
    {
    }
}
