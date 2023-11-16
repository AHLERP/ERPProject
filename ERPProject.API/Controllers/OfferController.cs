using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Business.ValidationRules.FluentValidation;
using ERPProject.Core.Aspects;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net.Mail;

namespace ERPProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;

        public OfferController(IMapper mapper, IOfferService offerService, IRequestService requestService)
        {
            _mapper = mapper;
            _offerService = offerService;
            _requestService = requestService;
        }

        [HttpPost("/AddOffer")]
        [ValidationFilter(typeof(OfferValidator))]
        public async Task<IActionResult> AddOffer(OfferDTORequest offerDTORequest)
        {
            Offer offer = _mapper.Map<Offer>(offerDTORequest);
            await _offerService.AddAsync(offer);

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);

            Log.Information("Offers => {@offerDTOResponse} => { Teklif Eklendi. }", offerDTOResponse);

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

            Log.Information("Offers => {@offer} => { Teklif Silindi. }", offer);

            return Ok(Sonuc<OfferDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateOffer")]
        //[ValidationFilter(typeof(OfferValidator))]
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

            Log.Information("Offers => {@offerDTOResponse} => { Teklif Güncellendi. }", offerDTOResponse);

            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }

        [HttpGet("/GetOffer/{offerId}")]
        public async Task<IActionResult> GetOffer(int offerId)
        {
            Offer offer = await _offerService.GetAsync(x => x.Id == offerId, "User", "Request");
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);

            Log.Information("Offers => {@offerDTOResponse} => { Teklif Getirildi. }", offerDTOResponse);
            //Log.Information($"Offers => {offerDTOResponse} =>  Teklif Getirildi.");

            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }

        [HttpGet("/GetOffers")]
        public async Task<IActionResult> GetOffers()
        {

            var offers = await _offerService.GetAllAsync(x => x.IsActive == true, "User", "Request");
            if (offers == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }
            List<OfferDTOResponse> offerDTOResponseList = new();
            foreach (var offer in offers)
            {
                offerDTOResponseList.Add(_mapper.Map<OfferDTOResponse>(offer));
            }

            Log.Information("Offers => {@offerDTOResponse} => { Teklifleri Getir. }", offerDTOResponseList);
            return Ok(Sonuc<List<OfferDTOResponse>>.SuccessWithData(offerDTOResponseList));
        }
        [HttpPost("/UpdateAllOffer")]
        public async Task<IActionResult> UpdateAll(OfferDTORequest offerDTORequest)
        {
            var offer = _mapper.Map<Offer>(offerDTORequest);
            var response = await _offerService.UpdateAllAsync(offer);

            List<OfferDTOResponse> offerDTOResponse = new();
            foreach (var item in response) 
            {

                offerDTOResponse.Add(_mapper.Map<OfferDTOResponse>(item));
            }
            Log.Information("Offers => {@offerDTOResponse} => { Teklifler Toplu Güncellendi. }", offerDTOResponse);


            return Ok(Sonuc<List<OfferDTOResponse>>.SuccessWithData(offerDTOResponse));

        }
    }
}
