namespace Azenix.LogReader
{
    public class Constants
    {
        public const string LOGFILTER_PATTERN =
            @"^(?<remote>[^\s]*)\s(?<host>[^\s]*)\s(?<user>[^\s]*)\s\[(?<time>[^\]]*)\]\s""(?<method>\S+)(?:\s+(?<path>((\w{4,5}:\/\/)|(\/))(?<endpoint>(?<service>[^?\/]*)[^?\d]*)[^\""]*)\s+\S*)?""\s(?<code>[^\s]*)\s(?<size>[^\s]*)(?:\s""(?<referer>[^\""]*)""\s""(?<agent>[^\""]*)"")?";
    }
}