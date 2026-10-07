using Models.PaymentRequest;
using Models.PaymentResponse;
using  Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddHttpLogging( options =>
{
    if(builder.Environment.IsDevelopment())
    {
        options.LoggingFields = HttpLoggingFields.All;
    }
    else
    {
        options.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders| HttpLoggingFields.ResponsePropertiesAndHeaders|HttpLoggingFields.Duration;
    }
});


builder.Services.AddControllers();
// builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
var app = builder.Build();

app.UseHttpLogging();
app.MapControllers();


app.MapGet("/",() =>
    {
        return "Payment Api is running";
    }
);
app.MapPost("/payment", (PaymentRequest request) =>
{
    // return $"Amount : {payment.Amount} and currency :{payment.Currency}";

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

    return response;
}

);


app.MapGet("/payment", (decimal amount, string currency) =>
{
    return $"Amount : {amount} and currency : {currency}";
});

app.Run();


