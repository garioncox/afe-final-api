using System.Security.Claims;
using System.Text.Json.Serialization;
using afe_final_api.Data;
using afe_final_api.services;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = "https://auth.snowse.duckdns.org/realms/advanced-frontend/",
        ValidAudience = "garion-auth-class"
    };
    options.Authority = "https://auth.snowse.duckdns.org/realms/advanced-frontend/";
});
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<PostgresContext>(o => o.UseNpgsql(Environment.GetEnvironmentVariable("db") ?? envVars["db"]));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<ITransactionEventService, TransactionEventService>();
builder.Services.AddScoped<IBudgetTransactionEventService, BudgetTransactionEventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseCors(
    p => p
     .AllowAnyHeader()
     .AllowAnyMethod()
     .AllowAnyOrigin());

app.MapGet("/api", () => "healthy");
app.MapGet("/authOnly", (ClaimsPrincipal user) =>
{
    if (user.Identity?.IsAuthenticated == true)
    {
        Console.WriteLine($"Authenticated user: {user?.FindFirst(ClaimTypes.Email)?.Value}");
        return $"Authenticated user: {user?.FindFirst(ClaimTypes.Email)?.Value}";
    }

    Console.WriteLine("User not authenticated");
    return "User not authenticated";
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
