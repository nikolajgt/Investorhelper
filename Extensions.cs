using Restful.Model.YahooFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful
{
    public static class Extensions
    {

        public static bool Validator(FinanceModel financemodel, string symbol)
        {
            if(financemodel.symbol == symbol)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

    }
}
