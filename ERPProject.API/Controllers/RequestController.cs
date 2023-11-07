using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Business.ValidationRules.FluentValidation;
using ERPProject.Core.Aspects;
using ERPProject.Entity.DTO.ProductDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class RequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet("/Requests")]
        public async Task<IActionResult> GetRequests()
        {
            var requests= await _requestService.GetAllAsync(x=>x.IsActive==true,"User","Product");
            if (requests==null)
            {
                return NotFound(Sonuc<List<RequestDTOResponse>>.SuccessNoDataFound());
            }

            List<RequestDTOResponse> requestDTOResponseList = new();

            foreach (var request in requests)
            {
                requestDTOResponseList.Add(_mapper.Map<RequestDTOResponse>(request));
            }

            Log.Information("Requests => {@requestDTOResponse} => { İstekler Getirildi. }", requestDTOResponseList);

            return Ok(Sonuc<List<RequestDTOResponse>>.SuccessWithData(requestDTOResponseList));
            
        }
        [HttpPost("/UpdateRequest")]
        [ValidationFilter(typeof(RequestValidator))]
        public async Task<IActionResult> UpdateRequest(RequestDTORequest requestDTORequest)
        {
            var request = await _requestService.GetAsync(e => e.Id == requestDTORequest.Id);
            if (request == null) 
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());
            }

            _mapper.Map(requestDTORequest, request);
            await _requestService.UpdateAsync(request);

            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(request);

            Log.Information("Requests => {@requestDTOResponse} => { İstek Güncellendi. }", requestDTOResponse);

            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));

        }

        [HttpDelete("/RemoveRequest/{requestId}")]
        public async Task<IActionResult> RemoveRequest(int requestId)
        {
            var request = await _requestService.GetAsync(e => e.Id == requestId);
            if (request == null)
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());
            }

            await _requestService.RemoveAsync(request);

            Log.Information("Requests => {@request} => { İstek Silindi. }", request);

            return Ok(Sonuc<RequestDTOResponse>.SuccessWithoutData());

        }

        [HttpPost("/AddRequest")]
        //[ValidationFilter(typeof(RequestValidator))]
        public async Task<IActionResult> AddRequest(RequestDTORequest requestDTORequest)
        {
            var request = _mapper.Map<Request>(requestDTORequest);

            await _requestService.AddAsync(request);
            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(request);

            Log.Information("Requests => {@requestDTOResponse} => { İstek Eklendi. }", requestDTOResponse);
            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));


        }

        [HttpGet("/Requests/{userId}")]
        public async Task<IActionResult> GetRequests(int userId)
        {
            var requests = await _requestService.GetAllAsync(e=>e.UserId==userId && e.IsActive == true, "User", "Product");
            if (requests == null)
            {
                return NotFound(Sonuc<List<RequestDTOResponse>>.SuccessNoDataFound());
            }

            List<RequestDTOResponse> requestDTOResponseList = new();

            foreach (var request in requests)
            {
                requestDTOResponseList.Add(_mapper.Map<RequestDTOResponse>(request));
            }

            Log.Information("Requests => {@requestDTOResponse} => { Kullanıcıya Göre İstek Getirildi. }", requestDTOResponseList);
            return Ok(Sonuc<List<RequestDTOResponse>>.SuccessWithData(requestDTOResponseList));

        }
        [HttpGet("/Request/{requestId}")]
        public async Task<IActionResult> GetRequest(int requestId)
        {
            var request = await _requestService.GetAsync(e => e.Id == requestId);
            if (request == null)
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());
            }

            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(request);


            Log.Information("Requests => {@requestDTOResponse} => { İstek Getirildi. } ", requestDTOResponse);

            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));


        }

    }
}
