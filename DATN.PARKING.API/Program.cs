using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.ImplementMethod;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork<ParkingContext>,UnitOfWork<ParkingContext>>();
//builder.Services.AddScoped<IServiceParking,ServiceParking>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DATN.PARKING.API", Version = "v1" });
});
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ParkingContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.EnableRetryOnFailure()));
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
