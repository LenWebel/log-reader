using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azenix.LogReader.models;

namespace Azenix.LogReader.services
{
    public class LogQuery : ILogQuery<W3CLog>
    {
        private IEnumerable<W3CLog> _data;

        public LogQuery(IEnumerable<W3CLog> data)
        {
            _data = data;
        }
        
        public Task<IEnumerable<TReturn>> GetUniqueValuesAsync<TReturn>(Func<W3CLog,TReturn> selector)
        {
            return Task.FromResult(_data.Select(selector).Distinct());
        }

        public Task<IEnumerable<IGrouping<TReturn, W3CLog>>> TopAsync<TReturn>(int number, Func<W3CLog, TReturn> selector)
        {
            return Task.FromResult(_data.GroupBy(selector).OrderByDescending( g => g.Count()).Take(number));
        }

        public void LoadData(IEnumerable<W3CLog> log)
        {
            _data = log;
        }
    }
}