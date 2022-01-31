using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log.reader.that.could.be.an.elk.stack.models;

namespace log.reader.that.could.be.an.elk.stack.services
{
    public interface ILogQuery<TModel> where TModel : class
    {
        Task<IEnumerable<TReturn>> GetUniqueValuesAsync<TReturn>(Func<TModel, TReturn> selector);

        Task<IEnumerable<IGrouping<TReturn, W3CLog>>> TopAsync<TReturn>(int number, Func<TModel, TReturn> selector);
        void LoadData(IEnumerable<TModel> log);
    }
}