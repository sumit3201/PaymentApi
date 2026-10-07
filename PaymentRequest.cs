namespace Models.PaymentRequest;
public class PaymentRequest
{
    public decimal Amount {get; set;}

    public string Currency {get; set;} = string.Empty;
}