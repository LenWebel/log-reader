using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azenix.LogReader;
using Azenix.LogReader.models;
using Azenix.LogReader.services;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Tests.Azenix.LogReader
{
    /// <summary>
    /// This is not an exhaustive list of tests.
    /// </summary>
    public class LogQueryTests : IClassFixture<ServiceProviderFixture>
    {
        private readonly ILogQuery<W3CLog> _logQueryService;
        
        public LogQueryTests(ServiceProviderFixture host)
        {
            _logQueryService = host.ServiceProvider.GetRequiredService<ILogQuery<W3CLog>>();
        }
        
        [Fact]
        public async Task FetchTop3_FromData_ReturnsTop3()
        {
            var data = new List<W3CLog>
            {
                new() { IpAddress = "192.168.0.4" },
                new() { IpAddress = "192.168.0.1" },
                new() { IpAddress = "192.168.0.5" },
                new() { IpAddress = "192.168.0.1" },
                new() { IpAddress = "192.168.0.2" },
                new() { IpAddress = "192.168.0.1" },
                new() { IpAddress = "192.168.0.2" },
                new() { IpAddress = "192.168.0.2" },
                new() { IpAddress = "192.168.0.3" },
                new() { IpAddress = "192.168.0.3" },
            };

            _logQueryService.LoadData(data);
            
            var top3OfProperty = (await _logQueryService.TopAsync(3, p => p.IpAddress)).ToArray();
            top3OfProperty[0].Key.ShouldBe("192.168.0.1");
            top3OfProperty[1].Key.ShouldBe("192.168.0.2");
            top3OfProperty[2].Key.ShouldBe("192.168.0.3");
            
        }
        
        [Fact]
        public async Task FetchUnique_FromData_IpAddress()
        {
            var data = new List<W3CLog>
            {
                new() { IpAddress = "192.168.0.4" },
                new() { IpAddress = "192.168.0.1" },
                new() { IpAddress = "192.168.0.5" },
                new() { IpAddress = "192.168.0.1" },
                new() { IpAddress = "192.168.0.2" },
                new() { IpAddress = "192.168.0.1" },
                new() { IpAddress = "192.168.0.2" },
                new() { IpAddress = "192.168.0.2" },
                new() { IpAddress = "192.168.0.3" },
                new() { IpAddress = "192.168.0.3" },
            };

            _logQueryService.LoadData(data);
            
            var top3OfProperty = (await _logQueryService.GetUniqueValuesAsync( p => p.IpAddress)).ToArray();
            top3OfProperty.Length.ShouldBe(5);
            
        }
        
    }
}