using AutoMapper;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;

namespace Nutrivida.API.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // MAPPINGS para DTOS
            CreateMap<User, UserForRegisterDTO>().ReverseMap();
            CreateMap<Sale, SaleDTO>().ReverseMap();
            CreateMap<Expensive, ExpensiveDTO>().ReverseMap();
            CreateMap<FinancialRecord, FinancialRecordDTO>().ReverseMap();
            CreateMap<ExpensiveCategory, ExpensiveCategoryDTO>().ReverseMap();
            CreateMap<SaleCategory, SaleCategoryDTO>().ReverseMap();

            // MAPPINGS para VMS
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Sale, SaleVM>().ReverseMap();
            CreateMap<Expensive, ExpensiveVM>().ReverseMap();
            CreateMap<FinancialRecord, FinancialRecordVM>().ReverseMap();
            CreateMap<ExpensiveCategory, ExpensiveCategoryVM>().ReverseMap();
            CreateMap<SaleCategory, SaleCategoryVM>().ReverseMap();
        }
    }
}
