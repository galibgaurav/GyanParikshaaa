using GyanPariksha.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanPariksha.Controllers
{
    public class AppController:Controller
    {
        public IGyanPariksha _gyanPariksha;
        public IConfigurationRoot _config;
        public AppController(IGyanPariksha gyanPariksha,IConfigurationRoot config)
        {
            _gyanPariksha = gyanPariksha;
            _config = config;
        }

        public IActionResult Index()
        {
            //throw new InvalidOperationException();
            return View();
        }

        public IActionResult sayHello()
        {
            return Json(_gyanPariksha.sayHello(_config["ApplicationInfo:Name"]));
        }


    }
}
