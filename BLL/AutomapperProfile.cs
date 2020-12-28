using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Order, OrderRequest>().
                ForPath(dest => dest.Pickup.Latitude, opt => opt.MapFrom(src => src.PickupLatitude)).
                ForPath(dest => dest.Pickup.Longitude, opt => opt.MapFrom(src => src.PickupLongitude)).
                ForPath(dest => dest.Dropoff.Latitude, opt => opt.MapFrom(src => src.DropoffLatitude)).
                ForPath(dest => dest.Dropoff.Longitude, opt => opt.MapFrom(src => src.DropoffLongitude));
            CreateMap<OrderRequest, Order>().
                ForPath(dest => dest.PickupLatitude, opt => opt.MapFrom(src => src.Pickup.Latitude)).
                ForPath(dest => dest.PickupLongitude, opt => opt.MapFrom(src => src.Pickup.Longitude)).
                ForPath(dest => dest.DropoffLatitude, opt => opt.MapFrom(src => src.Dropoff.Latitude)).
                ForPath(dest => dest.DropoffLongitude, opt => opt.MapFrom(src => src.Dropoff.Longitude));
            CreateMap<Order, OrderResponse>().
                ForPath(dest => dest.Pickup.Latitude, opt => opt.MapFrom(src => src.PickupLatitude)).
                ForPath(dest => dest.Pickup.Longitude, opt => opt.MapFrom(src => src.PickupLongitude)).
                ForPath(dest => dest.Dropoff.Latitude, opt => opt.MapFrom(src => src.DropoffLatitude)).
                ForPath(dest => dest.Dropoff.Longitude, opt => opt.MapFrom(src => src.DropoffLongitude));
        }
    }
}
