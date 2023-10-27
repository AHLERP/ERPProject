using AutoMapper;
using ERPProject.Entity.DTO.RequestDetailDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.RequestDetailMap
{
    public class RequestDetailDTORequestMapper:Profile
    {
        public RequestDetailDTORequestMapper()
        {
            CreateMap<RequestDetail, RequestDetailDTORequest>();
            CreateMap<RequestDetailDTORequest, RequestDetail>();
        }
    }
}
