using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.RequestDetailDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class RequestDetailController : Controller
    {
        private readonly IRequestDetailService _requestDetailService;
        private readonly IMapper _mapper;

        public RequestDetailController(IMapper mapper, IRequestDetailService requestDetailService)
        {
            _mapper = mapper;
            _requestDetailService = requestDetailService;
        }

        [HttpPost("/AddRequestDetail")]
        public async Task<IActionResult> AddRequestDetail(RequestDetailDTORequest requestDetailDTORequest)
        {

            var requestDetail = _mapper.Map<RequestDetail>(requestDetailDTORequest);
            await _requestDetailService.AddAsync(requestDetail);

            RequestDetailDTOResponse requestDetailDTOResponse = _mapper.Map<RequestDetailDTOResponse>(requestDetail);

            Log.Information("RequestDetails => {@requestDetailDTOResponse}", requestDetailDTOResponse);

            return Ok(Sonuc<RequestDetailDTOResponse>.SuccessWithData(requestDetailDTOResponse));

        }

        [HttpPost("/UpdateRequestDetail")]
        public async Task<IActionResult> UpdateRequestDetail(RequestDetailDTORequest requestDetailDTORequest)
        {
            var requestDetail = await _requestDetailService.GetAsync(e=>e.Id== requestDetailDTORequest.Id);

            if (requestDetail==null)
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());

            }
            _mapper.Map(requestDetailDTORequest, requestDetail);
            await _requestDetailService.UpdateAsync(requestDetail);

            RequestDetailDTOResponse requestDetailDTOResponse = _mapper.Map<RequestDetailDTOResponse>(requestDetail);

            Log.Information("RequestDetails => {@requestDetailDTOResponse}", requestDetailDTOResponse);

            return Ok(Sonuc<RequestDetailDTOResponse>.SuccessWithData(requestDetailDTOResponse));
        }

        [HttpDelete("/RemoveRequestDetail/{requestDetailId}")]
        public async Task<IActionResult> RemoveRequestDetail(int requestDetailId)
        {
            var requestDetail = await _requestDetailService.GetAsync(e => e.Id == requestDetailId);

            if (requestDetail == null)
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());

            }
            
            await _requestDetailService.RemoveAsync(requestDetail);

            Log.Information("RequestDetails => {@requestDetail}", requestDetail);

            return Ok(Sonuc<RequestDetailDTOResponse>.SuccessWithoutData());
        }



        [HttpGet("/RequestDetails")]
        public async Task<IActionResult> GetRequestDetails()
        {
            var requestDetails = await _requestDetailService.GetAllAsync();
            if (requestDetails == null)
            {
                return NotFound(Sonuc<List<RequestDetailDTOResponse>>.SuccessNoDataFound());
            }

            List<RequestDetailDTOResponse> requestDTOResponseList = new();

            foreach (var requestDetail in requestDetails)
            {
                requestDTOResponseList.Add(_mapper.Map<RequestDetailDTOResponse>(requestDetail));
            }

            Log.Information("RequestDetails => {@requestDetailDTOResponse}", requestDTOResponseList);

            return Ok(Sonuc<List<RequestDetailDTOResponse>>.SuccessWithData(requestDTOResponseList));

        }

        [HttpGet("/RequestDetail/{requestDetailId}")]
        public async Task<IActionResult> GetRequestDetail(int requestDetailId)
        {
            var requestDetail = await _requestDetailService.GetAsync(e => e.Id == requestDetailId);
            if (requestDetail==null)
            {
                return NotFound(Sonuc<RequestDetailDTOResponse>.SuccessNoDataFound());
            }
            RequestDetailDTOResponse requestDTOResponse = _mapper.Map<RequestDetailDTOResponse>(requestDetail);


            Log.Information("RequestDetails => {@requestDetailDTOResponse}", requestDTOResponse);
            return Ok(Sonuc<RequestDetailDTOResponse>.SuccessWithData(requestDTOResponse));
        }
        

    }
}
