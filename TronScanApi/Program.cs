using TronScanApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TronScanApiOptions>(builder.Configuration.GetSection(TronScanApiOptions.SectionName));
builder.Services.AddHttpClient<ISecurityService, SecurityService>("TronScanClient");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();