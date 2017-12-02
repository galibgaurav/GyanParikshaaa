using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GyanPariksha
{
    public class Program
    {
        //Gaurav-Kind of console app l isten to port 80 
        public static void Main(string[] args)
        {
            //Gaurav-Build a web host and listen to web request
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()//Gaurav- it says what says what class to use to setup how to listen to web request
                .Build();
    }
}
