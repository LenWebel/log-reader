using System;
using log.reader.that.could.be.an.elk.stack;
using log.reader.that.could.be.an.elk.stack.mappers;
using log.reader.that.could.be.an.elk.stack.models;
using log.reader.that.could.be.an.elk.stack.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace tests.log.reader.could.be.an.elk.stack
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