using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace log.reader.that.could.be.an.elk.stack.services
{
    public interface ILogReader<T> where T : class
    {
        Task<IEnumerable<T>> ReadLogAsync(string path);
        IEnumerable<T> ReadLog(string path);
    }
}