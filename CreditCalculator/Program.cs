using Kalkulator.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kalkulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup start = new Startup();
            start.Configure (args);
            
        }
    }
}