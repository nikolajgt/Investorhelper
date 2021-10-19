using System;
using System.Collections.Generic;
using System.Text;

namespace Restful.Model.YahooFinance
{
    public record FinancialData
    {
        public currentPrice currentPrice { get; init; }
    }

    public record currentPrice
    {
        public decimal raw { get; init; }
    }
}
