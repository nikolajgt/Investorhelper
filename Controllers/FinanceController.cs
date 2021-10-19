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
    public class FinanceController
    {
        // Dummy endpoint class


        private readonly IMongoConnection _repository;

        public FinanceController(IMongoConnection repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDocument(FinanceModel financemodel)
        {
            var id = await _repository.CreateAsync(financemodel);
            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            var financemodel = await _repository.Get(Guid.Parse(id));
            return new JsonResult(financemodel);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var financemodel = await _repository.GetAsync();
            return new JsonResult(financemodel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, FinanceModel financemodel)
        {
            var result = await _repository.UpdateAsync(Guid.Parse(id), financemodel);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repository.DeleteAsync(Guid.Parse(id));
            return new JsonResult(result);
        }
    }
}
