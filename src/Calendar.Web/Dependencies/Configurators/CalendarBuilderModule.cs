using System;

using Autofac;
using Autofac.Core;

using Calendar.Builder;

using Calendar.Builder.ReleaseProviders;
using Calendar.Builder.ReleaseProviders.TMD;
using Microsoft.Extensions.Configuration;
using TMDbLib.Client;

namespace Calendar.Web.Dependencies.Configurators
{
    public class CalendarBuilderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReleaseEventCalendarBuilder>();

            builder.RegisterType<TMDReleaseProvider>()
                .As<ReleaseProviderBase>()
                .WithParameter("minDate", DateTime.Today.AddYears(-1));

            builder.Register(ctx =>
            {
                var apiKey = ctx.Resolve<IConfiguration>().GetSection("ExternalServices:TvRange").GetValue<string>("ApiKey");
                return new TMDbClient(apiKey);
            });

            builder.RegisterType<TMDSerialIdProvider>()       
                .Keyed<ISerialIdProvider>("serialIdProvider");

            builder.RegisterType<CachedSerialIdProvider>()
                .As<ISerialIdProvider>()
                .WithParameter(ResolvedParameter.ForNamed<ISerialIdProvider>("serialIdProvider"));
        }
    }
}