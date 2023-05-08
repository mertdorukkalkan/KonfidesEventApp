using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Microsoft.AspNetCore.Identity;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthenticateManager>().As<IAuthenticateService>().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWorks>().InstancePerLifetimeScope();
        builder.RegisterType<RoleManager>().As<IRoleService>().InstancePerLifetimeScope();
    }
}