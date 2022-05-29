using AutoMapper;
using MB.T6.Entities;
using MB.T6.Web.Models.Cars;

namespace MB.T6.Web.AutoMapper
{
    public class CarAutoMapperProfile : Profile
    {
        public CarAutoMapperProfile()
        {
            CreateMap<Car, CarListViewModel>();
        }
    }
}
