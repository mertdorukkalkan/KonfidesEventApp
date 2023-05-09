using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.Validation;
using DataAccess;
using Domain.IdentityModels;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthenticateManager>().As<IAuthenticateService>().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWorks>().InstancePerLifetimeScope();
        builder.RegisterType<RoleManager>().As<IRoleService>().InstancePerLifetimeScope();
        builder.RegisterType<AddressManager>().As<IAddressService>().InstancePerLifetimeScope();
        builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
        builder.RegisterType<CityManager>().As<ICityService>().InstancePerLifetimeScope();
        builder.RegisterType<StatusManager>().As<IStatusService>().InstancePerLifetimeScope();
        builder.RegisterType<EventManager>().As<IEventService>().InstancePerLifetimeScope();
        builder.RegisterType<TicketManager>().As<ITicketService>().InstancePerLifetimeScope();

        #region Validation

        builder.RegisterType<LoginValidator>().As<IValidator<LoginModel>>().InstancePerLifetimeScope();

        #endregion
       

    }
}