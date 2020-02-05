using AutoMapper;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;

namespace Nutrivida.API.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Expensive, ExpensiveDto>().ReverseMap();
            CreateMap<FinancialRecord, FinancialRecordDto>().ReverseMap();
            CreateMap<ExpensiveCategory, ExpensiveCategoryDto>().ReverseMap();
            CreateMap<SaleCategory, SaleCategoryDto>().ReverseMap();
        }
    }
}
