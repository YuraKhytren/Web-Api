using AutoMapper;
using Task12NetCoreBackEnd.Models;
using Task12NetCoreBackEnd.ViewModel;

namespace Task12NetCoreBackEnd.Mapping
{
    public class FinanceTypeToFinanceTypeViewModelProfile :Profile
    {
        public FinanceTypeToFinanceTypeViewModelProfile()
        {
            CreateMap<FinanceType, FinanceTypeViewModel>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("Id", opt => opt.MapFrom(src => src.Id))
                .ForMember("Income", opt => opt.MapFrom(src => src.Income));

            CreateMap<FinanceTypeViewModel, FinanceType>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("Id", opt => opt.MapFrom(src => src.Id))
                .ForMember("Income", opt => opt.MapFrom(src => src.Income));

        }
    }
}
