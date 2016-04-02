using System;
using Microsoft.Owin.Hosting;

namespace OWINTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var options = new StartOptions
            {
                ServerFactory = "Nowin",
                Port = 9000
            };

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }

        }
    }
}
