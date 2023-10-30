using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;

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
            var requests= await _requestService.GetAllAsync();
            if (requests==null)
            {
                return NotFound(Sonuc<List<RequestDTOResponse>>.SuccessNoDataFound());
            }

            List<RequestDTOResponse> requestDTOResponseList = new();

            foreach (var request in requests)
            {
                requestDTOResponseList.Add(_mapper.Map<RequestDTOResponse>(request));
            }
            return Ok(Sonuc<List<RequestDTOResponse>>.SuccessWithData(requestDTOResponseList));
            
        }
        [HttpPost("/UpdateRequest")]
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

            return Ok(Sonuc<RequestDTOResponse>.SuccessWithoutData());

        }

        [HttpPost("/AddRequest")]
        public async Task<IActionResult> AddRequest(RequestDTORequest requestDTORequest)
        {
            var request = _mapper.Map<Request>(requestDTORequest);

            await _requestService.AddAsync(request);
            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(request);

            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));


        }

        [HttpGet("/Requests/{userId}")]
        public async Task<IActionResult> GetRequests(int userId)
        {
            var requests = await _requestService.GetAllAsync(e=>e.UserId==userId);
            if (requests == null)
            {
                return NotFound(Sonuc<List<RequestDTOResponse>>.SuccessNoDataFound());
            }

            List<RequestDTOResponse> requestDTOResponseList = new();

            foreach (var request in requests)
            {
                requestDTOResponseList.Add(_mapper.Map<RequestDTOResponse>(request));
            }
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

            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));


        }

    }
}
