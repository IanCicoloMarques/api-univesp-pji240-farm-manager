using api_univesp_pji240_farm_manager.Data;
using api_univesp_pji240_farm_manager.Interface.Data;
using api_univesp_pji240_farm_manager.Interface.UseCase;
using api_univesp_pji240_farm_manager.UseCase;
using Microsoft.AspNetCore.HttpOverrides;
using MySqlConnector;
using Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
}); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();


builder.Services.AddCors();

string dbcs = builder.Configuration.GetConnectionString("Database");
Console.WriteLine(dbcs);

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddSingleton<IDataProductRepository, DataProductRepository>();
builder.Services.AddSingleton<IDataCustomerRepository, DataCustomerRepository>();
builder.Services.AddSingleton<IDataOrderRepository, DataOrderRepository>();
builder.Services.AddSingleton<ICommoditySolver, CommoditySolver>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://www.kolima.net"));
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.MapHealthChecks("/health");

app.MapControllers();


app.Run("http://*:5001");