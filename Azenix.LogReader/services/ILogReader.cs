using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azenix.LogReader.services
{
    public interface ILogReader<T> where T : class
    {
        Task<IEnumerable<T>> ReadLogAsync(string path);
        IEnumerable<T> ReadLog(string path);
    }
}