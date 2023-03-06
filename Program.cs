using CarPoolTask5.Data;
using CarPoolTask5.Services;
using CarPoolTask5.Interfaces;
using CarPoolTask5.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarPoolingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CarPoolingApiConnnectionString")));
builder.Services.AddScoped<IUserCredentials, UserServices>();
builder.Services.AddScoped<ILocations,LocationServices>();
builder.Services.AddScoped<IOfferRide, OfferRideServices>();
builder.Services.AddScoped<IBookRide, BookRideService>();
builder.Services.AddScoped<IUserRides,UserRideService>();
var app = builder.Build();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
