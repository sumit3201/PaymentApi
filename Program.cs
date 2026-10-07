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

//configure or register controller support
builder.Services.AddControllers();
// builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
var app = builder.Build();

app.UseHttpLogging();

//Map controller endpoint so request can reach to them 
app.MapControllers();


app.MapGet("/",() =>
    {
        return "Payment Api is running";
    }
);


app.MapGet("/payment", (decimal amount, string currency) =>
{
    return $"Amount : {amount} and currency : {currency}";
});

app.Run();


