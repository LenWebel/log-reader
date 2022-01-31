
using System.Threading.Tasks;
using Azenix.LogReader.mappers;
using Azenix.LogReader.models;
using Azenix.LogReader.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Azenix.LogReader
{
    static class Program
    {
        static  Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            var application = provider.GetRequiredService<IApplication>();
            application.Run().Wait();

            return Task.CompletedTask;
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IApplication, Application>()
                        .AddTransient<IW3CLogReader, W3CLogReader>()
                        .AddTransient<ILogQuery<W3CLog>, LogQuery>()
                        .AddTransient<IW3CMapper, W3CMapper>());
        }
    }
}