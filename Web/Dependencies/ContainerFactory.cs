using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Autofac;

using Autofac;

using SerialsCalendar;

namespace Web.Dependencies
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

            builder.RegisterModule(new CalendarModule());
        }
    }
}