using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Dtos;

namespace ProductShoppingWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedSellersController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        private readonly IBannedSellerService _bannedSellerService;

        public BannedSellersController(ISellerService sellerService, IBannedSellerService bannedSellerService)
        {
            _sellerService = sellerService;
            _bannedSellerService = bannedSellerService;
        }

        [HttpPost]
        public ActionResult<ServiceResponse<BannedSellerDto>> BanSeller(SellerBanDto sellerBanDto)
        {
            ServiceResponse<BannedSellerDto> response = new ServiceResponse<BannedSellerDto>();
            if (sellerBanDto.SellerDto.IsBanned)
            {
                response.Message = "Cannot ban already banned seller";
                return BadRequest(response);
            }
            try
            {
                var bannedSeller = _sellerService.BanSeller(sellerBanDto.SellerDto.UniqueSellerIdentificator);
                var sellerBan = _bannedSellerService.AddBannedSeller(sellerBanDto);
                if (bannedSeller is not null && sellerBan is not null)
                {
                    response.Data = sellerBan;
                    response.Message = "Seller successfully banned";
                    return Ok(response);
                } 
            } catch (Exception e)
            {
                response.Message = e.Message;
                response.Data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return BadRequest();
        }
    }
}
