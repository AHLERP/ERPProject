using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.StockDetailDTO;
using ERPProject.Entity.DTO.StockDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class StockDetailController : Controller
    {
        private readonly IStockDetailService _stockDetailService;
        private readonly IMapper _mapper;

        public StockDetailController(IMapper mapper, IStockDetailService stockDetailService)
        {
            _mapper = mapper;
            _stockDetailService = stockDetailService;
        }

        [HttpPost("/AddStockDetail")]
        public async Task<IActionResult> AddStockDetail(StockDetailDTORequest stockDetailDTORequest)
        {
            StockDetail stockDetail = _mapper.Map<StockDetail>(stockDetailDTORequest);
            await _stockDetailService.AddAsync(stockDetail);

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetail);

            Log.Information("StockDetails => {@stockDetailDTOResponse}", stockDetailDTOResponse);

            return Ok(Sonuc<StockDetailDTOResponse>.SuccessWithData(stockDetailDTOResponse));
        }


        [HttpDelete("/RemoveStockDetail/{stockDetailId}")]

        public async Task<IActionResult> RemoveStockDetail(long stockDetailId)
        {
            StockDetail stockDetail = await _stockDetailService.GetAsync(x=>x.Id == stockDetailId);
            if (stockDetail == null)
            {
                return NotFound(Sonuc<StockDetailDTOResponse>.SuccessNoDataFound());
            }

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetail);

            Log.Information("StockDetails => {@stockDetailDTOResponse}", stockDetailDTOResponse);

            return Ok(Sonuc<StockDetailDTOResponse>.SuccessWithData(stockDetailDTOResponse));
        }

        [HttpPost("/UpdateStockDetail")]
        public async Task<IActionResult> UpdateStockDetail(StockDetailDTORequest stockDetailDTORequest)
        {
            StockDetail stockDetail = await _stockDetailService.GetAsync(x=>x.Id == stockDetailDTORequest.Id);
            if(stockDetail == null)
            {
                return NotFound(Sonuc<StockDetailDTOResponse>.SuccessNoDataFound());
            }

            stockDetail = _mapper.Map(stockDetailDTORequest,stockDetail);
            await _stockDetailService.UpdateAsync(stockDetail);

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetail);

            Log.Information("StockDetails => {@stockDetailDTOResponse}", stockDetailDTOResponse);

            return Ok(Sonuc<StockDetailDTOResponse>.SuccessWithData(stockDetailDTOResponse));
        }

        [HttpGet("/StockDetail/{stockDetailId}")]
        public async Task<IActionResult> GetStockDetail(long stockDetailId)
        {
            StockDetail stockDetail = await _stockDetailService.GetAsync(x=>x.Id == stockDetailId,"Stock","User");
            if(stockDetail == null)
            {
                return NotFound(Sonuc<StockDetailDTOResponse>.SuccessNoDataFound());
            }

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetail);

            Log.Information("StockDetails => {@stockDetailDTOResponse}", stockDetailDTOResponse);

            return Ok(Sonuc<StockDetailDTOResponse>.SuccessWithData(stockDetailDTOResponse));
        }

        [HttpGet("/StockDetails")]
        public async Task<IActionResult> GetStockDetails()
        {
            var stockDetails = await _stockDetailService.GetAllAsync(x=>x.IsActive == true , "Stock","User");
            if (stockDetails == null)
            {
                return NotFound(Sonuc<StockDetailDTOResponse>.SuccessNoDataFound());
            }

            List<StockDetailDTOResponse> stockDetailDTOResponseList = new();
            foreach (var stockdetail in stockDetails)
            {
                stockDetailDTOResponseList.Add(_mapper.Map<StockDetailDTOResponse>(stockdetail));
            }

            Log.Information("StockDetails => {@stockDetailDTOResponse}", stockDetailDTOResponseList);

            return Ok(Sonuc<List<StockDetailDTOResponse>>.SuccessWithData(stockDetailDTOResponseList));
        }

        [HttpGet("/StockDetailsByStock/{stockId}")]
        public async Task<IActionResult> GetStockDetailsByStock(long stockId)
        {
            var stockDetails = await _stockDetailService.GetAllAsync(x => x.IsActive == true && x.StockId == stockId, "Stock", "User");
            if (stockDetails == null)
            {
                return NotFound(Sonuc<StockDetailDTOResponse>.SuccessNoDataFound());
            }

            List<StockDetailDTOResponse> stockDetailDTOResponseList = new();
            foreach (var stockdetail in stockDetails)
            {
                stockDetailDTOResponseList.Add(_mapper.Map<StockDetailDTOResponse>(stockdetail));
            }

            Log.Information("StockDetails => {@stockDetailDTOResponse}", stockDetailDTOResponseList);

            return Ok(Sonuc<List<StockDetailDTOResponse>>.SuccessWithData(stockDetailDTOResponseList));
        }

        // StockDetailsByUser ???

        
    }
}
