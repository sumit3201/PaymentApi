using Microsoft.AspNetCore.Mvc;
using Models.PaymentRequest;
using Models.PaymentResponse;
namespace Contollers.PaymentController;

[ApiController]
[Route("payment")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public  ActionResult<PaymentResponse> CreatePayment(PaymentRequest request)
    {
        PaymentResponse response = new PaymentResponse()
        {
            PaymentId = "Pay-123",
            Amount = request.Amount,
            Currency = request.Currency,
            Status = " Success"

        };

            // PaymentResponse response = new PaymentResponse();
        
            // response.PaymentId = "Pay-123";
            // response.Amount = request.Amount;
            // response.Currency = request.Currency;
            // response.Status = " Success";

        return Created("", response);
    }
}