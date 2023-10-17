using api_univesp_pji240_farm_manager.Data;
using api_univesp_pji240_farm_manager.Interface.Data;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddSingleton<IDataProductRepository, DataProductRepository>();
builder.Services.AddSingleton<IDataCustomerRepository, DataCustomerRepository>();
builder.Services.AddSingleton<IDataOrderRepository, DataOrderRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://www.kolima.net"));
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
