using AutoMapper;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.RequestMap
{
    public class RequestDTOResponseMapper:Profile
    {
        public RequestDTOResponseMapper()
        {
            CreateMap<Request, RequestDTOResponse>().
                ForMember(dest => dest.UserName, opt =>
                {
                    opt.MapFrom(src => src.User.Name);
                }).
                ForMember(dest => dest.ProductName, opt =>
                {
                    opt.MapFrom(src => src.Product.Name);
                }).ReverseMap();
            
        }
    }
}
