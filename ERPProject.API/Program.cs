using Autofac;
using Autofac.Extensions.DependencyInjection;
using ERPProject.Business.Abstract;
using ERPProject.Business.Concrete;
using ERPProject.DataAccess.Abstract.DataManagement;
using ERPProject.DataAccess.Concrete.EntityFramework.Context;
using ERPProject.DataAccess.Concrete.EntityFramework.DataManagement;
using FluentValidation.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/myLog-.txt",rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ERPContext>();
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IStockDetailService, StockDetailManager>();
builder.Services.AddScoped<IOfferService, OfferManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<IInvoiceService, InvoiceManager>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseAuthorization();

app.MapControllers();

app.Run();
