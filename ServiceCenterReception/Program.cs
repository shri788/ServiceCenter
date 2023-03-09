using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Data;
using ServiceCenterReception.Repository;
using ServiceCenterReception.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<serviceCenterDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("pgServerConnection"));
});

// startup services starts here
//builder.Services.AddHostedService<RecurringMethodsService>();
builder.Services.AddScoped<ICustomerProfileRepo, CustomerProfileRepo>();
builder.Services.AddScoped<ICustomerProfileSvc, CustomerProfileSvc>();
// startup services ends here

builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();