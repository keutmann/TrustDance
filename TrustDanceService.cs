using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustDance
{
    public class TrustDanceService
    {
        private IDisposable webApp = null;

        public void Start()
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://+:80/");
            startOptions.Urls.Add("https://+:443");
            webApp = WebApp.Start<Startup>(startOptions);

            Process.Start("http://trust.dance"); // Launch the browser.
        }


        public void Pause()
        {
            if (webApp != null)
                webApp.Dispose();
        }

        public void Continue()
        {
            Start();
        }

        public void Stop()
        {
            if (webApp != null)
                webApp.Dispose();
        }

    }
}
