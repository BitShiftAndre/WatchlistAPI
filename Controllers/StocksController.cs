using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watchlist_API.Models;
using Watchlist_API.Repositories.Interfaces;

namespace Watchlist_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ITradingDataRepo tradingDataRepo;
        public StocksController(ITradingDataRepo tradingDataRepo)
        {
            this.tradingDataRepo = tradingDataRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockData>>> Get()
        {
            return (await tradingDataRepo.GetDefaultSymbols()).ToList();
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<StockData>> Get([FromRoute] string symbol)
        {
            return Ok(await tradingDataRepo.GetStock(symbol));
        }
    }
}
