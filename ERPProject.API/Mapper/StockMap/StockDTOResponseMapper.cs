using AutoMapper;
using ERPProject.Entity.DTO.StockDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.StockMap
{
    public class StockDTOResponseMapper:Profile
    {
        public StockDTOResponseMapper()
        {
            CreateMap<Stock,StockDTOResponse>();
            CreateMap<StockDTOResponse, Stock>();
        }
    }
}
