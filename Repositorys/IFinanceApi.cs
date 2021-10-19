using Restful.Model.YahooFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Repositorys
{
    public interface IFinanceApi
    {
        Task<FinanceModel> GetFinanceData(string symbol);
        
    }
}
