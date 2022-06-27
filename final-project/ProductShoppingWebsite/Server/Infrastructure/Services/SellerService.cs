using AutoMapper;
using ProductShoppingWebsite.Server.Infrastructure.Repositories;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Dtos;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;

        private readonly IReportService _reportService;

        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IReportService reportService, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _reportService = reportService;
            _mapper = mapper;
        }

        public List<Seller> GetReportedSellers()
        {
            return _sellerRepository.GetSellers()
                .ToList()
                .FindAll(seller => seller.IsBanned == false && _reportService.GetReportsForSeller(seller.SellerId).Any());
        }

        public List<SellerDto> GetReportedSellersDtoWithReports()
        {
            var tableUtilNumberCounter = 1;
            var reportedSellersDto = _mapper.Map<List<SellerDto>>(GetReportedSellers());

            foreach (var sellerDto in reportedSellersDto)
            {
                sellerDto.TableUtilNumber = tableUtilNumberCounter;
                tableUtilNumberCounter++;
            }

            reportedSellersDto.ForEach(seller => seller.ReportsforSeller = _reportService
                .GetReportsForSellerByUniqueId(seller.UniqueSellerIdentificator));

            return reportedSellersDto;
        }

        public Seller GetSellerByUniqueSellerId(int uniqueSellerId)
        {
            return _sellerRepository.GetSellers()
                    .FirstOrDefault(seller => seller.UniqueSellerIdentificator == uniqueSellerId);
        }

        public SellerDto GetSellerDtoByUniqueSellerId(int uniqueSellerId)
        {
            return _mapper.Map<SellerDto>(GetSellerByUniqueSellerId(uniqueSellerId));
        }

        public SellerDto BanSeller(int uniqueSellerId)
        {
            var seller = _sellerRepository.GetSellers()
                .FirstOrDefault(seller => seller.UniqueSellerIdentificator == uniqueSellerId);
            seller.IsBanned = true;
            _sellerRepository.UpdateSeller(seller);
            _sellerRepository.Save();
            return _mapper.Map<SellerDto>(seller);
        }

    }
}
