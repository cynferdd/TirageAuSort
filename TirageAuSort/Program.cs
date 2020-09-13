using Infrastructure;
using Infrastructure.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace TirageAuSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            serviceProvider.GetService<App>().Run(args);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IFileManager, FileManager>();

            

            // required to run the application
            services.AddTransient<App>();

            return services;
        }
    }
}
