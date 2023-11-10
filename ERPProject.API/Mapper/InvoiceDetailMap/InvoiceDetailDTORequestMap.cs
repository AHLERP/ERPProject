using AutoMapper;
using ERPProject.Entity.DTO.InvoiceDetailDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.InvoiceDetailMap
{
    public class InvoiceDetailDTORequestMap:Profile
    {
        public InvoiceDetailDTORequestMap()
        {
            CreateMap<InvoiceDetailDTORequest, InvoiceDetail>();
            CreateMap<InvoiceDetail, InvoiceDetailDTORequest>();
        }
    }
}
