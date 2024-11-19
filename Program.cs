using System.Text.Json.Serialization;
using afe_final_api.Data;
using afe_final_api.services;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.MapGet("/api", () => "healthy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
