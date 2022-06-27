using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Dtos;

namespace ProductShoppingWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet("reported-sellers")]
        public ActionResult<ServiceResponse<List<SellerDto>>> GetReportedSellers()
        {
            var result = _sellerService.GetReportedSellersDtoWithReports();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<SellerDto>> GetSellerById(int id)
        {
            var response = new ServiceResponse<SellerDto>();
            var result = _sellerService.GetSellerDtoByUniqueSellerId(id);
            if (result is null)
            {
                response.Message = $"Seller with id {id} has not been found.";
                response.Success = false;
                return Ok(response);
            }
            response.Data = result;
            response.Success = true;
            response.Message = "";
            return Ok(response);
        }
    }
}
