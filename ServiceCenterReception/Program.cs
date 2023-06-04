using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceCenterReception.Data;
using ServiceCenterReception.Repository;
using ServiceCenterReception.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<serviceCenterDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("pgServerConnection"));
    option.EnableSensitiveDataLogging();
});

// startup services starts here
//builder.Services.AddHostedService<RecurringMethodsService>();
builder.Services.AddScoped<IVehicleServiceDetailRepo, VehicleServiceDetailRepo>();
builder.Services.AddScoped<IVehicleDetailsRepo, VehicleDetailsRepo>();
builder.Services.AddScoped<ICustomerProfileRepo, CustomerProfileRepo>();
builder.Services.AddScoped<ICustomerProfileSvc, CustomerProfileSvc>();
builder.Services.AddScoped<IVehicleServiceTaskSvc, VehicleServiceTaskSvc>();
builder.Services.AddScoped<IVehicleServiceTaskRepo, VehiclServiceTaskRepo>();
builder.Services.AddScoped<IFinalBillRepo, FinalBillRepo>();
builder.Services.AddScoped<IFinalBillSvc, FinalBillSvc>();
builder.Services.AddScoped<IVehicleServiceDeliveryRepo, VehicleServiceDeliveryRepo>();
builder.Services.AddScoped<IVehicleServiceDeliverySvc, VehicleServiceDeliverySvc>();

builder.Services.AddAutoMapper(typeof(Program));
// startup services ends here

builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
