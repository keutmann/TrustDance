using Microsoft.Owin.Hosting;
using System;
using System.Diagnostics;
using Topshelf;

namespace TrustDance
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                return SetupTopshelf();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return -1;
            }
        }

        private static int SetupTopshelf()
        {
            var result = (int)HostFactory.Run(configurator =>
            {
                configurator.Service<TrustDanceService>(s =>
                {
                    s.ConstructUsing(() => new TrustDanceService());
                    s.WhenStarted(service => service.Start());
                    s.WhenPaused(service => service.Pause());
                    s.WhenContinued(service => service.Continue());
                    s.WhenStopped(service => service.Stop());
                });
            });

            return result;
        }

    }
}
