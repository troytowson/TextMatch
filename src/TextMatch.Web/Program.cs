using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TextMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(cfg =>
            {
                cfg.Service<ServiceHost>(svc =>
                {
                    svc.ConstructUsing(s => new ServiceHost());
                    svc.WhenStarted(s => s.Start());
                    svc.WhenStopped(s => s.Stop());
                });
                cfg.RunAsLocalSystem();
                cfg.SetServiceName("TextMatch.Web");
            });
        }
    }
}
