using AutoMapper;
using ERPProject.Entity.DTO.StockDetailDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.StockDetailMap
{
    public class StockDetailDTOResponseMapper:Profile
    {
        public StockDetailDTOResponseMapper()
        {
            CreateMap<StockDetail, StockDetailDTOResponse>().
                ForMember(dest => dest.DelivererName, opt =>
                {
                    opt.MapFrom(src => src.Deliverer.Name);
                }).
                ForMember(dest => dest.RecieverName, opt =>
                {
                    opt.MapFrom(src => src.Reciever.Name);
                }).
                ForMember(dest => dest.StockName, opt =>
                {
                    opt.MapFrom(src => src.Stock.Description);
                }).ReverseMap();
        }
    }
}
