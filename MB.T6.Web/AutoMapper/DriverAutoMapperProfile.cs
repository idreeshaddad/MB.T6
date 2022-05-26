using AutoMapper;
using MB.T6.Entities;
using MB.T6.Web.Models.Drivers;

namespace MB.T6.Web.AutoMapper
{
    public class DriverAutoMapperProfile : Profile
    {
        public DriverAutoMapperProfile()
        {
            CreateMap<Driver, DriverListViewModel>();
        }
    }
}
