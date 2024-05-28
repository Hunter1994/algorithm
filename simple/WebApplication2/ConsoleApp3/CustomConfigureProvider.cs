using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class CustomConfigureProvider:ConfigurationProvider
    {
        public CustomConfigureProvider()
        { 
        }
        public override void Load()
        {
            Data = new Dictionary<string, string>() { { "a", "aaaaa" }, { "b", "bbbbb" } };
        }
    }
}
