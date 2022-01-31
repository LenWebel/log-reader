using System.Collections;
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
    public class LogReaderTests : IClassFixture<ServiceProviderFixture>
    {
        private readonly IW3CLogReader _logReaderService;

        public LogReaderTests(ServiceProviderFixture host)
        {
            _logReaderService = host.ServiceProvider.GetRequiredService<IW3CLogReader>();
        }
          
        [Fact]
        public async Task OpenDaTaSource_Return23Records()
        {
            var records = await _logReaderService.ReadLogAsync("data/data.txt");
            records.Count().ShouldBe(23);
        }
        
        [Fact]
        public async Task OnRead_ReturnType_ShouldBeW3CLogArray()
        {
            var records = await _logReaderService.ReadLogAsync("data/data.txt");

            records.ShouldBeAssignableTo<IEnumerable<W3CLog>>();

        }

        [Fact] public async Task IsMapped_Remote()
        {
            var records = await _logReaderService.ReadLogAsync("data/data.txt");

            records.ShouldBeAssignableTo<IEnumerable<W3CLog>>();
            records.First().IpAddress.ShouldBe("177.71.128.21");

        }
        [Fact] public async Task IsMapped_Url()
        {
            var records = await _logReaderService.ReadLogAsync("data/data.txt");

            records.ShouldBeAssignableTo<IEnumerable<W3CLog>>();
            records.First().Url.ShouldBe("/intranet-analytics/");

        }
    }
}