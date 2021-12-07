using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("save")]
        public IActionResult Save(CreditCard creditCard)
        {
            var result = _creditCardService.Save(creditCard);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("getcards")]
        public IActionResult GetCards()
        {
            var result = _creditCardService.GetCards();
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
