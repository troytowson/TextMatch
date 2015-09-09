using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMatch
{
    public class ServiceHost
    {
        private IDisposable _webServer;

        public void Start()
        {
            _webServer = WebApp.Start<StartUp>("http://localhost:7000");
        }

        public void Stop()
        {
            _webServer.Dispose();
        }
    }
}
