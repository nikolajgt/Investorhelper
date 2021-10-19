using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Restful.Model.YahooFinance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Repositorys
{
    public class MongoConnection : IMongoConnection
    {

        private readonly IMongoCollection<FinanceModel> _repository;                       
        private readonly string _dbName = "InvestorHelper";
        private readonly string _dbCollection = "StockInformation";

        // Depdendency Injection 
        public MongoConnection(IMongoClient client)
        {
            var database = client.GetDatabase(_dbName);
            var collection = database.GetCollection<FinanceModel>(_dbCollection);
            _repository = collection;
        }

        public async Task<Guid> CreateAsync(FinanceModel financemodel)
        {
            await _repository.InsertOneAsync(financemodel);

            return financemodel.Id;
        }
        
        public Task<FinanceModel> Get(Guid id) 
        {
            var filter = Builders<FinanceModel>.Filter.Eq(c => c.Id, id);
            var financemodel = _repository.Find(filter).FirstOrDefaultAsync();

            return financemodel;
        }


        // Få fat i alle stocks dokumenter i DB
        public async Task<IEnumerable<FinanceModel>> GetAsync()
        {
            var filter = await _repository.Find(_ => true).ToListAsync();
            return filter;
        }

        // Samme som den i bunden men bruger ID til at opdaterer istedet
        public async Task<bool> UpdateAsync(Guid id, FinanceModel financemodel)
        {
            var filter = Builders<FinanceModel>.Filter.Eq(c => c.Id, id);
            var update = Builders<FinanceModel>.Update
                .Set(c => c.symbol, financemodel.symbol)
                .Set(c => c.price, financemodel.price)
                .Set(c => c.defaultKeyStatistics, financemodel.defaultKeyStatistics)
                .Set(c => c.financialData, financemodel.financialData);

            var result = await _repository.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }


        //Herfra starter ApiController CRUD aka det rigtige


        // Delete fra DB udfra id

        public async Task<bool> DeleteAsync(Guid id)
        {
            var filter = Builders<FinanceModel>.Filter.Eq(c => c.Id, id);
            var result = await _repository.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }

        // Få fat i en stock ud fra symbol
        public async Task<IEnumerable<FinanceModel>> GetBySymbolAsync(string symbol)
        {
            var filter = Builders<FinanceModel>.Filter.Eq(c => c.symbol, symbol);
            var financemodel = await _repository.Find(filter).ToListAsync();
            return financemodel;
        }


        // Indsætter stock i DB udfra symbol
        public async Task<string> CreateFinanceAsync(string symbol)
        {
            var instance = new FinanceApi();
            await _repository.InsertOneAsync(await instance.GetFinanceData(symbol));

            return symbol;
        }


        //Updaterer udfra sumbol hvis en stock den eksisterer  ASYNC
        public async Task<bool> UpdateIfExistAsync(string symbol, FinanceModel financemodel)
        {
            var instance = new FinanceApi();
            var financeApi = await instance.GetFinanceData(symbol);

            var filter = Builders<FinanceModel>.Filter.Eq(c => c.symbol, symbol);

            var update = Builders<FinanceModel>.Update
                .Set(c => c.symbol, financeApi.symbol)
                .Set(c => c.price, financeApi.price)
                .Set(c => c.defaultKeyStatistics, financeApi.defaultKeyStatistics)
                .Set(c => c.financialData, financeApi.financialData);

            var result = await _repository.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;
        }

        
    }

}
