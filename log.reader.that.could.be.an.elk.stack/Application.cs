using System;
using System.Linq;
using System.Threading.Tasks;
using log.reader.that.could.be.an.elk.stack.models;
using log.reader.that.could.be.an.elk.stack.services;

namespace log.reader.that.could.be.an.elk.stack
{
    
    public interface IApplication
    {
        Task Run();
    }
    public class Application : IApplication
    {
        private readonly IW3CLogReader _reader;
        private readonly ILogQuery<W3CLog> _query;

        public Application(IW3CLogReader reader, ILogQuery<W3CLog> query)
        {
            _reader = reader;
            _query = query;
        }

        public async Task Run()
        {
            var log = await _reader.ReadLogAsync("data/data.txt");
            _query.LoadData(log);
            var uniqueIpAddresses = (await _query.GetUniqueValuesAsync(p => p.Remote)).ToArray();
            var top3Urls = (await _query.TopAsync(3, p => p.Url));
            var top3IpAddresses = (await _query.TopAsync(3, p => p.Remote));
           
            
            Console.WriteLine($"Number of Unique IP Addresses: {uniqueIpAddresses.Length}");
            Console.WriteLine($"Top 3 IP Addresses:\n\r {String.Join("\n\r ",top3IpAddresses.Select(i => i.Key))}");
            Console.WriteLine($"Top 3 Url's:\n\r {String.Join("\n\r ",top3Urls.Select(i => i.Key))}");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            
            Console.ReadKey();
        }
    }
}