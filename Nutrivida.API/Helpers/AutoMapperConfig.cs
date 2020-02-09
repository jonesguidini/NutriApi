using AutoMapper;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;
using System.Linq;

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
            CreateMap<Sale, SaleVM>()
                .ForMember(x => x.SaleCategory, y => y.MapFrom(z => z.SaleCategory.Category))
            .ReverseMap();

            CreateMap<Expensive, ExpensiveVM>()
                .ForMember(x => x.ExpensiveCategory, y => y.MapFrom(z => z.ExpensiveCategory.Category))
            .ReverseMap();


            CreateMap<FinancialRecord, FinancialRecordVM>()
                .ForMember(x => x.ValueTotalExpensives, y => y.MapFrom(z => z.Expensives.Sum(x => x.Value)))
                .ForMember(x => x.ValueTotalSales, y => y.MapFrom(z => z.Sales.Sum(x => x.Value)))
            .ReverseMap();

            CreateMap<ExpensiveCategory, ExpensiveCategoryVM>().ReverseMap();
            CreateMap<SaleCategory, SaleCategoryVM>().ReverseMap();
        }
    }
}
