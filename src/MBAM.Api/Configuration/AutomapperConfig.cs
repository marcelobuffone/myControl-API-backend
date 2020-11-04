using AutoMapper;
using MBAM.Api.ViewModels;
using MBAM.Business.Models.Archive;
using MBAM.Business.Models.Payment;

namespace MBAM.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Archive, ArchiveViewModel>().ReverseMap();
        }
    }
}
