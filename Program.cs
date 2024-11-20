using System.Security.Claims;
using System.Text.Json.Serialization;
using afe_final_api.Data;
using afe_final_api.services;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.Audience = "garion-auth-class";
    options.Authority = "https://auth.snowse.duckdns.org/realms/advanced-frontend/protocol/openid-connect/certs";
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
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
        Console.WriteLine($"Authenticated user: {user.Identity.Name}");
        return $"Authenticated user: {user.Identity.Name}";
    }

    Console.WriteLine("IsAuthenticated: " + user.Identity?.IsAuthenticated);
    Console.WriteLine("Claims: " + string.Join(", ", user.Claims.Select(c => c.Type + ": " + c.Value)));

    Console.WriteLine("User not authenticated");
    return "User not authenticated";
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
