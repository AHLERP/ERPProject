using AutoMapper;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.InvoiceMap
{
    public class InvoiceDTOResponseMap : Profile
    {
        public InvoiceDTOResponseMap()
        {
            CreateMap<Invoice, InvoiceDTOResponse>().
                ForMember(dest => dest.SupplierName, opt =>
                {
                    opt.MapFrom(src => src.Offer.SupplierName);
                }).
                ForMember(dest => dest.CompanyName, opt =>
                {
                    opt.MapFrom(src => src.Company.Name);
                }).
                ForMember(dest => dest.ProductName, opt =>
                {
                    opt.MapFrom(src => src.Product.Name);
                }).ReverseMap();
        }
    }
}
