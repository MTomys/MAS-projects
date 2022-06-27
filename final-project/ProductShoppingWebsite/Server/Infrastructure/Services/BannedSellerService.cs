using AutoMapper;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared.Dtos;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Services
{
    public class BannedSellerService : IBannedSellerService
    {
        private IBannedSellerRepository _bannedSellerRepository;
        private ISellerService _sellerService;

        private IMapper _mapper;

        public BannedSellerService(IBannedSellerRepository bannedSellerRepository, ISellerService sellerService, IMapper mapper)
        {
            _bannedSellerRepository = bannedSellerRepository;
            _sellerService = sellerService;
            _mapper = mapper;
        }

        public BannedSellerDto AddBannedSeller(SellerBanDto sellerBanDto)
        {
            var sellerToBan = _sellerService.GetSellerByUniqueSellerId(sellerBanDto.SellerDto.UniqueSellerIdentificator);
            BannedSeller bannedSeller = new ()
            {
                BannedSellerId = sellerToBan.SellerId,
                DateOfBan = DateTime.Now,
                BanReasonDescription = sellerBanDto.BanReasonDescription,
                DecisionAdmin = sellerBanDto.DecisionAdmin,
                ArchivizationDate = DateTime.Now.AddMonths(3),
                Seller = sellerToBan,
            };
            _bannedSellerRepository.InsertBannedSeller(bannedSeller);
            _bannedSellerRepository.Save();
            return _mapper.Map<BannedSellerDto>(bannedSeller);
        }
    }
}
