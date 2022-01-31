using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using log.reader.that.could.be.an.elk.stack;
using log.reader.that.could.be.an.elk.stack.models;
using log.reader.that.could.be.an.elk.stack.services;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace tests.log.reader.could.be.an.elk.stack
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
                new() { Remote = "192.168.0.4" },
                new() { Remote = "192.168.0.1" },
                new() { Remote = "192.168.0.5" },
                new() { Remote = "192.168.0.1" },
                new() { Remote = "192.168.0.2" },
                new() { Remote = "192.168.0.1" },
                new() { Remote = "192.168.0.2" },
                new() { Remote = "192.168.0.2" },
                new() { Remote = "192.168.0.3" },
                new() { Remote = "192.168.0.3" },
            };

            _logQueryService.LoadData(data);
            
            var top3OfProperty = (await _logQueryService.TopAsync(3, p => p.Remote)).ToArray();
            
            top3OfProperty[0].Key.ShouldBe("192.168.0.1");
            top3OfProperty[1].Key.ShouldBe("192.168.0.2");
            top3OfProperty[2].Key.ShouldBe("192.168.0.3");
        }
    }
}