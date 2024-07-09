using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ConfigurationMonitor : IConfigurationMonitor
    {
        byte[] _appsettingsHash;
        public ConfigurationMonitor(IConfiguration conf) {

            _appsettingsHash = ComputeHash("appSettings.json");
            ChangeToken.OnChange<IConfigurationMonitor>(() => conf.GetReloadToken(), cm => InvokeChanged(), this);
        }
        public bool MonitoringEnabled { get; set; }
        public string CurrentState { get; set; }

        void InvokeChanged()
        {
            if (MonitoringEnabled)
            {
                byte[] appsettingsHash = ComputeHash("appSettings.json");
                if (!_appsettingsHash.SequenceEqual(appsettingsHash)
                  )
                {
                    _appsettingsHash = appsettingsHash;

                    Console.WriteLine("文件变更");
                }
            }
            Console.WriteLine("调用日志");

        }
        static byte[] ComputeHash(string filePath)
        {
            var runCount = 1;

            while (runCount < 4)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        using (var fs = File.OpenRead(filePath))
                        {
                            return System.Security.Cryptography.SHA1
                                .Create().ComputeHash(fs);
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (IOException ex)
                {
                    if (runCount == 3)
                    {
                        throw;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(Math.Pow(2, runCount)));
                    runCount++;
                }
            }

            return new byte[20];
        }
    }
}
