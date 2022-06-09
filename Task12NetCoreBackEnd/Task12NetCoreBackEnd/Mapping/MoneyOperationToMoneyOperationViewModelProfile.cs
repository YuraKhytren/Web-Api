using AutoMapper;
using Task12NetCoreBackEnd.Models;
using Task12NetCoreBackEnd.ViewModel;

namespace Task12NetCoreBackEnd.Mapping
{
    public class MoneyOperationToMoneyOperationViewModelProfile : Profile
    {
        public MoneyOperationToMoneyOperationViewModelProfile() 
        {
            CreateMap<MoneyOperation, MoneyOperationViewModel>()
               .ForMember("Description", opt => opt.MapFrom(src => src.Description))
               .ForMember("Date", opt => opt.MapFrom(src => src.Date))
               .ForMember("Money", opt => opt.MapFrom(src => src.Money))
               .ForMember("Id", opt => opt.MapFrom(src => src.Id));

            CreateMap<MoneyOperationViewModel, MoneyOperation>()
                .ForMember("Description", opt => opt.MapFrom(src => src.Description))
                .ForMember("Date", opt => opt.MapFrom(src => src.Date))
                .ForMember("Money", opt => opt.MapFrom(src => src.Money))
                .ForMember("Id", opt => opt.MapFrom(src => src.Id));
        }
    }
}
