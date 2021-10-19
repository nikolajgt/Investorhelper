using Restful.Model.YahooFinance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Repositorys
{
    public interface IMongoConnection
    {
        /// MONGO DB CRUD
        ///  
 
        Task<Guid> CreateAsync(FinanceModel financemodel);
        Task<FinanceModel> Get(Guid id);
        Task<IEnumerable<FinanceModel>> GetBySymbolAsync(string symbol);
        Task<IEnumerable<FinanceModel>> GetAsync();
        Task<bool> UpdateAsync(Guid id, FinanceModel financemodel);
        Task<bool> DeleteAsync(Guid id);

        /// Finance API AUTOMATIC 
        /// 

        Task<string> CreateFinanceAsync(string symbol);
        Task<bool> UpdateIfExistAsync(string symbol, FinanceModel financemodel);
    } 

}
