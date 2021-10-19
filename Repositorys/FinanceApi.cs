using Restful.Model.YahooFinance;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Repositorys
{
    public class FinanceApi : IFinanceApi
    {

        private async Task<FinanceModel> InitializeClient(string symbol)
        {
            string connectionString = "https://yh-finance.p.rapidapi.com/stock/v2/get-summary?symbol=" + symbol + "&region=US";

            var client = new RestClient(connectionString);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Parameters.Clear();
            request.AddHeader("x-rapidapi-key", "c50a8c25e1msha531523845a2408p137be8jsnec835d616a8e");
            request.AddHeader("x-rapidapi-host", "yh-finance.p.rapidapi.com");
            request.AddParameter("application/json", ParameterType.RequestBody);

            var result = await client.GetAsync<FinanceModel>(request);
            result.symbol = symbol;
            return result;
        }

        public async Task<FinanceModel> GetFinanceData(string symbol)
        {
            var data = await InitializeClient(symbol);
            return data;
        }


    }
}
