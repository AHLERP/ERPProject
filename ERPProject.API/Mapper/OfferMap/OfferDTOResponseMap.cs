using AutoMapper;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.OfferMap
{
    public class OfferDTOResponseMap : Profile
    {
        public OfferDTOResponseMap()
        {
            CreateMap<Offer, OfferDTOResponse>();
            CreateMap<OfferDTOResponse, Offer>();
        }
    }
}
