using System;
using System.Collections.Generic;
using System.Text;

namespace Restful.Model.YahooFinance
{
    public record PriceModel
    {
        public regularMarketOpen regularMarketOpen { get; init; }
        public regularMarketPreviousClose regularMarketPreviousClose { get; init; }
        public regularMarketChangePercent regularMarketChangePercent { get; init; }
        public regularMarketDayHigh regularMarketDayHigh { get; init; }
        public preMarketPrice preMarketPrice { get; init; }
        public postMarketPrice postMarketPrice { get; init; }
        public preMarketChangeProcent preMarketChangeProcent { get; init; }
        public postMarketChangeProcent postMarketChangeProcent { get; init; }
    }

    public class regularMarketOpen
    {
        public decimal raw { get; init; }
    }

    public class regularMarketPreviousClose
    {
        public decimal raw { get; init; }
    }

    public class regularMarketChangePercent
    {
        public decimal raw { get; init; }
    }

    public class regularMarketDayHigh
    {
        public decimal raw { get; init; }
    }

    public class preMarketPrice
    {
        public decimal raw { get; init; }
    }
    public class postMarketPrice
    {
        public decimal raw { get; init; }
    }

    public class preMarketChangeProcent
    {
        public decimal raw { get; init; }
    }

    public class postMarketChangeProcent
    {
        public decimal raw { get; init; }
    }
}
