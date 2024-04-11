using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Domain.Services;
using InvestmentManagement.Domain.Settings;
using InvestmentManagement.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);


builder.Services.AddDbContext<InvestmentContext>(options =>
{
    options.UseSqlServer(appSetting.SqlServerConnection);
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInvestmentAccountService, InvestmentAccountService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddScoped<IAssetService, AssetService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
