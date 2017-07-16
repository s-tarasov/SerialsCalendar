using Autofac;
using Autofac.Extensions.DependencyInjection;

using Calendar.Web.Dependencies.Configurators;

using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Web.Dependencies
{
    public static class ContainerFactory
    {
        public static IContainer Create(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            Configure(builder, services);

            return builder.Build();
        }

        private static void Configure(ContainerBuilder builder, IServiceCollection services)
        {
            AutofacRegistration.Populate(
                builder,
                services);

            builder
                .RegisterModule(new CachingModule())
                .RegisterModule(new DataModule())
                .RegisterModule(new CalendarBuilderModule());
        }
    }
}