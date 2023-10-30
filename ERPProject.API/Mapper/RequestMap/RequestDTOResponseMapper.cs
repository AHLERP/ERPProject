using AutoMapper;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.RequestMap
{
    public class RequestDTOResponseMapper:Profile
    {
        public RequestDTOResponseMapper()
        {
            CreateMap<Request, RequestDTOResponse>();
            CreateMap<RequestDTOResponse, Request>();
        }
    }
}
