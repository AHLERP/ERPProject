using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OfferController(IMapper mapper, IOfferService offerService)
        {
            _mapper = mapper;
            _offerService = offerService;
        }

        [HttpPost("/AddOffer")]
        public async Task<IActionResult> AddOffer(OfferDTORequest offerDTORequest)
        {
            Offer offer = _mapper.Map<Offer>(offerDTORequest);
            await _offerService.AddAsync(offer);

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }
        [HttpDelete("/RemoveOffer/{offerId}")]
        public async Task<IActionResult> RemoveOffer(int offerId)
        {
            Offer offer = await _offerService.GetAsync(x => x.Id == offerId);
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }

            await _offerService.RemoveAsync(offer);
            return Ok(Sonuc<OfferDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateOffer")]
        public async Task<IActionResult> UpdateOffer(OfferDTORequest offerDTORequest)
        {
            Offer offer = await _offerService.GetAsync(x => x.Id == offerDTORequest.Id);
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }
            offer = _mapper.Map(offerDTORequest, offer);
            await _offerService.UpdateAsync(offer);

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }

        [HttpGet("/GetOffer/{offerId}")]
        public async Task<IActionResult> GetOffer(int offerId)
        {
            Offer offer = await _offerService.GetAsync(x => x.Id == offerId);
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }
    }
}
