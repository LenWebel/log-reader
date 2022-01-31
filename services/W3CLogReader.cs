using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log.reader.that.could.be.an.elk.stack.mappers;
using log.reader.that.could.be.an.elk.stack.models;


namespace log.reader.that.could.be.an.elk.stack.services
{
    public class W3CLogReader : IW3CLogReader
    {
        private readonly IW3CMapper _logMapper;

        public W3CLogReader(IW3CMapper logMapper)
        {
            _logMapper = logMapper;
        }

        public async Task<IEnumerable<W3CLog>> ReadLogAsync(string path)
        {
            var lines = await File.ReadAllLinesAsync(path);
            List<W3CLog> structuredLog = new List<W3CLog>();
            var pattern = Constants.LOGFILTER_PATTERN;

            foreach (var line in lines)
            {
                var split = Regex.Split(line, pattern);
                structuredLog.Add(_logMapper.Map(split));
            }

            return structuredLog;
        }

        public IEnumerable<W3CLog> ReadLog(string path)
        {
            throw new NotImplementedException();
        }
    }
}