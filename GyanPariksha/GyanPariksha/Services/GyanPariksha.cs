using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GyanPariksha.Services
{
    public class GyanPariksha:IGyanPariksha
    {
        public string sayHello(string message)
        {
            Debug.Write("hello "+message);
            return "hello " + message;
        }
    }
}
