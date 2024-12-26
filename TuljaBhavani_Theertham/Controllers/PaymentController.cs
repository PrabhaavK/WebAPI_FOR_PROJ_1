using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(Payment payment)
        {
            var result = await _paymentService.ProcessPayment(payment);
            if (result)
            {
                return Ok("Payment processed successfully");
            }
            return BadRequest("Failed to process payment");
        }
    }
}
