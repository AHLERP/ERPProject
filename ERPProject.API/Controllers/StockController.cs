using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.StockDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class StockController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStockService _stockService;

        public StockController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        [HttpGet("/Stocks")]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _stockService.GetAllAsync();
            if (stocks == null)
            {
                return NotFound(Sonuc<StockDTOResponse>.SuccessNoDataFound());
            }

            List<StockDTOResponse> stockDTOResponses = new();
            foreach (var stock in stocks)
            {
                stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(stock));
            }
            return Ok(Sonuc<List<StockDTOResponse>>.SuccessWithData(stockDTOResponses));
        }

        [HttpGet("/Stock/{stockId}")]
        public async Task<IActionResult> GetStock(int stockId)
        {
            var stock = await _stockService.GetAsync(e=>e.Id== stockId);
            if (stock == null)
            {
                return NotFound(Sonuc<StockDTOResponse>.SuccessNoDataFound());
            }
            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(stock);
            return Ok(Sonuc<StockDTOResponse>.SuccessWithData(stockDTOResponse));

        }

        [HttpPost("/AddStock")]
        public async Task<IActionResult> AddStock(StockDTORequest stockDTORequest)
        {
            var stock = _mapper.Map<Stock>(stockDTORequest);
            await _stockService.AddAsync(stock);
            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(stock);
            return Ok(Sonuc<StockDTOResponse>.SuccessWithData(stockDTOResponse));
        }

        [HttpPost("/UpdateStock")]
        public async Task<IActionResult> UpdateStock(StockDTORequest stockDTORequest)
        {
            var stock = await _stockService.GetAsync(e=>e.Id== stockDTORequest.Id);
            if (stock == null)
            {
                return NotFound(Sonuc<StockDTOResponse>.SuccessNoDataFound());
            }

            _mapper.Map(stockDTORequest, stock);
            await _stockService.UpdateAsync(stock);

            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(stock);
            return Ok(Sonuc<StockDTOResponse>.SuccessWithData(stockDTOResponse));
            
        }

        [HttpDelete("/RemoveStock/{stockId}")]
        public async Task<IActionResult> RemoveStock(int stockId)
        {
            var stock = await _stockService.GetAsync(e=>e.Id== stockId);
            if (stock == null)
            {
                return NotFound(Sonuc<StockDTOResponse>.SuccessNoDataFound());
            }
            await _stockService.RemoveAsync(stock);
            return Ok(Sonuc<StockDTOResponse>.SuccessWithoutData());

        }

    }
}
