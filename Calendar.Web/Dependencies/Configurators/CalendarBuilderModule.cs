using System;
using System.Net.Http;

using Autofac;
using Autofac.Core;

using Calendar.Builder;

using Calendar.Web.Configuration;
using Calendar.Builder.ReleaseProviders;
using Calendar.Builder.ReleaseProviders.TMD;
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

            builder.Register(ctx => new TMDbClient("fe5f5be42e7abbb3079056701867b87f"));

            builder.RegisterType<TMDSerialIdProvider>()       
                .Keyed<ISerialIdProvider>("serialIdProvider");

            builder.RegisterType<CachedSerialIdProvider>()
                .As<ISerialIdProvider>()
                .WithParameter(ResolvedParameter.ForNamed<ISerialIdProvider>("serialIdProvider"));
        }
    }
}