using Autofac;
using Autofac.Extensions.DependencyInjection;
using ERPProject.Business.Abstract;
using ERPProject.Business.Concrete;
using ERPProject.Business.DependencyResolvers.Autofac;
using ERPProject.DataAccess.Abstract.DataManagement;
using ERPProject.DataAccess.Concrete.EntityFramework.Context;
using ERPProject.DataAccess.Concrete.EntityFramework.DataManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddHttpContextAccessor();
//builder.Services.AddDbContext<ERPContext>();
//builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
//builder.Services.AddScoped<ICompanyService,CompanyManager>();
//builder.Services.AddScoped<IDepartmentService,DepartmentManager>();
//builder.Services.AddScoped<ICategoryService, CategoryManager>();
//builder.Services.AddScoped<IStockDetailService, StockDetailManager>();
//builder.Services.AddScoped<IOfferService, OfferManager>();
//builder.Services.AddScoped<IUserRoleService, UserRoleManager>();
//builder.Services.AddScoped<IUserService, UserManager>();
//builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
//builder.Services.AddScoped<IInvoiceService, InvoiceManager>();
//builder.Services.AddScoped<IBrandService, BrandManager>();


var app = builder.Build();


//AutofacBusinessModule
static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<StartupBase>();
    });
//




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
