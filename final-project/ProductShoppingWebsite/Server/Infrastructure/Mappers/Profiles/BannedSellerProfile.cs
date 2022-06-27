using AutoMapper;
using ProductShoppingWebsite.Shared.Dtos;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Mappers.Profiles
{
    public class BannedSellerProfile : Profile
    {
        public BannedSellerProfile()
        {
            CreateMap<BannedSeller, BannedSellerDto>();
        }
    }
}
