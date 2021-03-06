using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;
using Hotel.WebAPI.Mappings;
using Hotel.WebAPI.Middlewares;
using Hotel.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HotelDatabase");

builder.Services.AddDbContext<HotelDbContext>(options => options.UseMySql(connectionString, new MariaDbServerVersion("10.6")));
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddAutoMapper(typeof(AutoMappings));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseMiddleware<ExceptionMiddleware>();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
