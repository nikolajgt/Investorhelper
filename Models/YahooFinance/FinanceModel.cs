
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restful.Model.YahooFinance
{
    public record FinanceModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string symbol { get; set; }
        public PriceModel price { get; init; }  //Data before
        public DefaultKeyStatistics defaultKeyStatistics { get; init; }
        public FinancialData financialData { get; init; }  //Data now
    }
}
