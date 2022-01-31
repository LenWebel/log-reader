using System;
using System.Drawing;

namespace Azenix.LogReader.models
{
    public class W3CLog
    {

        public string Remote { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int Length { get; set; }
        public string Method { get; set; }
        public int StatusCode { get; set; }
        public string UserAgent { get; set; }
        public string Url { get; set; }
    }
}