using AutoMapper;
using ERPProject.Entity.DTO.RequestDetailDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.RequestDetailMap
{
    public class RequestDetailDTOResponseMapper:Profile
    {
        public RequestDetailDTOResponseMapper()
        {
            CreateMap<RequestDetail, RequestDetailDTOResponse>();
            CreateMap<RequestDetailDTOResponse, RequestDetail>();
        }
    }
}
