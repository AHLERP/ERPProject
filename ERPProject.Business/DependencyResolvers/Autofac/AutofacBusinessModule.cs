using Autofac;
using ERPProject.Business.Abstract;
using ERPProject.Business.Concrete;
using ERPProject.DataAccess.Abstract.DataManagement;
using ERPProject.DataAccess.Concrete.EntityFramework.Context;
using ERPProject.DataAccess.Concrete.EntityFramework.DataManagement;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContext>().SingleInstance();
            builder.RegisterType<ERPContext>().SingleInstance();
            builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>(); // IUnitOfWork istenirse EfUnitOfWork ver demek burası.
            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance(); // 1 tane instance oluştur herkese onu ver sürekli instance oluşturma demek.
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<InvoiceManager>().As<IInvoiceService>().SingleInstance();
            builder.RegisterType<OfferManager>().As<IOfferService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<RequestManager>().As<IRequestService>().SingleInstance();
            builder.RegisterType<RequestDetailManager>().As<IRequestDetailService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();
            builder.RegisterType<StockDetailManager>().As<IStockDetailService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRoleManager>().As<IUserRoleService>().SingleInstance();
        }
    }
}
