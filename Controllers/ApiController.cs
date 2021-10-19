using Microsoft.AspNetCore.Mvc;
using Restful.Model.YahooFinance;
using Restful.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController
    {
        // User interraction class, user skal kunne vælge stock ud fra symbol

        private readonly IMongoConnection _repository;


        //Dependeny injection
        public ApiController(IMongoConnection repository)
        {
            _repository = repository;
        }

        //Poster i db ud fra det valgte symbol
        [HttpPost("{symbol}")]
        public async Task<string> PostFromAPI(string symbol)
        {
            var result = await _repository.CreateFinanceAsync(symbol);

            return result;
        }

        // Opdaterer stock oplysninger hvis den eksisterer i db.
        // hører til MongoConnection.cs
        [HttpPut("{symbol}")]
        public async Task<IActionResult> UpdateFromAPI(string symbol, FinanceModel financemodel)
        {
            var result = await _repository.UpdateIfExistAsync(symbol, financemodel);
            return new JsonResult(result);
        }

        // Søger efter symbol i finance api og retuner hvis det blev fundet
        // hører til MongoConnection.cs
        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetBySymbol(string symbol)
        {
            var financemodel = await _repository.GetBySymbolAsync(symbol);
            return new JsonResult(financemodel);
        }


    }


}
