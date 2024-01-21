using CCXT.NET.Binance.Public;
using Microsoft.AspNetCore.Mvc;
using SharedDomain.Models;
using SharedDomain.Models.Interface;
using System;

namespace StockService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BinanceController : Controller
    {
        private readonly CryptoService _cryptoService;

        public BinanceController()
        {
            _cryptoService = new CryptoService(new PublicApi());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IApiBase> Index()
        {
            try
            {
                var data = await _cryptoService.GetOHLCVsAsync();
                return data;
            }
            catch (AggregateException ex)
            {
                return new ApiErrorResponse(ex.InnerExceptions.ToString());
            }

        }
    }
}
