using System;
using System.Globalization;
using Azenix.LogReader.models;

namespace Azenix.LogReader.mappers
{
    public interface IObjectMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        TDestination Map(TSource source);
        TSource Map(TDestination source);
    }

    public interface IW3CMapper : IObjectMapper<string[], W3CLog>
    {
    }

    public class W3CMapper : IW3CMapper
    {
        public W3CLog Map(string[] source)
        {
            DateTimeOffset.TryParseExact(source[6], "dd/MMM/yyyy:HH:mm:ss zzz",
                new CultureInfo("en-AU"), DateTimeStyles.AssumeUniversal, out DateTimeOffset time);
            
            return new W3CLog
            {
                IpAddress = source[3],
                Host = source[4],
                User = source[5],
                DateTime = time,
                Url = source[8],
                Length = int.Parse(source[12]),
                Method = source[7],
                StatusCode = int.Parse(source[11]),
                UserAgent = source[14],
            };
        }

        public string[] Map(W3CLog source)
        {
            throw new System.NotImplementedException();
        }
    }
}