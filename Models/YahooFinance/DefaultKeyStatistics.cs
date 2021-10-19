using System;
using System.Collections.Generic;
using System.Text;

namespace Restful.Model.YahooFinance
{
    public record DefaultKeyStatistics
    {
        public shortRatio shortRatio { get; init; }  // get short ratio of a stock
        public beta beta { get; set; }          //volatillity of a stocks, if over 1.0 is volatille.
    }

    public record shortRatio
    {
        public decimal raw { get; init; }
    }

    public record beta
    {
        public decimal raw { get; init; }
    }
}
