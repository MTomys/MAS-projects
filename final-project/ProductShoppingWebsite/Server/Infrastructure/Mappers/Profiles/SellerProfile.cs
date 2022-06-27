using AutoMapper;
using ProductShoppingWebsite.Shared.Dtos;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Mappers.Profiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<Seller, SellerDto>();
        }
    }
}
