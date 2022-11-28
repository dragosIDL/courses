using Application;

using Microsoft.Extensions.Hosting;

namespace Pokemons.Functions
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s => s.AddApplication())
                .Build();

            host.Run();
        }
    }
}