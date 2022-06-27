using FifthMiniProject.Domain.Entities;
using FifthMiniProject.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthMiniProject.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("person")]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            _dbContext.Add(person);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("buyer")]
        public async Task<ActionResult<Person>> CreateBuyer(Buyer buyer)
        {
            _dbContext.Add(buyer);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("seller")]
        public async Task<ActionResult<Person>> CreateSeller(Seller seller)
        {
            _dbContext.Add(seller);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
