using BackendTienda.Business;
using BackendTienda.Data;
using BackendTienda.Feautures.Employees;
using BackendTienda.Feautures.Positions;
using BackendTienda.Shared.Database;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))   
);

//builder.Services.AddDbContext<AppdbContext>(op =>
  //  op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

builder.Services.AddScoped<CategoryBusiness>();
builder.Services.AddScoped<ProductBusiness>();
builder.Services.AddScoped<OrderBusiness>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<PositionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();

app.UseStaticFiles();
app.UseCors("mypolicy");
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
