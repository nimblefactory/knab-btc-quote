using Knab.Btc.Quote.Adapters.CoinMarketCap;
using Knab.Btc.Quote.Adapters.CoinMarketCap.Handlers;
using Knab.Btc.Quote.Core;
using Knab.Btc.Quote.Core.Ports;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace Knab.Btc.Quote.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

        builder.Services.AddAuthorization(options =>
        {
            // By default, all incoming requests will be authorized according to the default policy.
            options.FallbackPolicy = options.DefaultPolicy;
        });
        builder.Services.AddRazorPages()
        .AddMicrosoftIdentityUI();

        // Register MediatR Request Handlers.
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCryptoQuoteHandler>());

        // Register Core services.
        builder.Services.AddScoped<ICryptoCurrencyService, CryptoCurrencyService>();
        builder.Services.AddScoped<ICryptoQuoteService, CryptoQuoteService>();
        builder.Services.AddTransient(x => new CryptoCurrencyApiSettings
        {
            BaseUrl = builder.Configuration["CoinMarketCap:Basic:BaseUrl"],
            ApiKey = builder.Configuration["CoinMarketCap:Basic:ApiKey"]
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllers();

        app.Run();
    }
}
