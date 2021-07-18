
using System;
using System.Collections.Generic;
using System.Linq;
using FinanceBackEnd.Infrastructure.Repositories;
using FinanceBackEnd.Models.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceBackEnd.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;

        private IRepository<Stock>  _repository;

        public StockController(
            ILogger<StockController> logger
            , IRepository<Stock> context)
        {
            _logger = logger;
            _repository = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Stock stock) 
        {   
            if (!ModelState.IsValid) 
            {
                return BadRequest();                           
            }

            var st = _repository.Insert(stock);
    
            _repository.GetContext().SaveChanges();
            
            return Ok(st);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] Stock stock) 
        {
            if (!ModelState.IsValid || stock.Id != id) 
            {
                return BadRequest();
            }

            try
            {
                var stockForUpdate = _repository.Get(id);

                if(stockForUpdate == null)
                    return NotFound();

                var stockUpdated =_repository.Update(stock);
                _repository
                    .GetContext()
                    .SaveChanges();

                return Ok(stockUpdated);
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);   
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) 
        {
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return _repository.Get().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
             return Ok(_repository.Get(id));
        }
    }
}