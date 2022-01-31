using System;
using Azenix.LogReader;
using Azenix.LogReader.mappers;
using Azenix.LogReader.models;
using Azenix.LogReader.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests.Azenix.LogReader
{
    public class ServiceProviderFixture
    {
        public ServiceProviderFixture()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IApplication, Application>()
                        .AddTransient<IW3CLogReader, W3CLogReader>()
                        .AddTransient<IW3CMapper, W3CMapper>()
                        .AddTransient<ILogQuery<W3CLog>, LogQuery>()).Build();
            
            using var serviceScope = host.Services.CreateScope();
            ServiceProvider = host.Services;
        }
        
        public IServiceProvider ServiceProvider { get; private set; }
    }
}