using System;
using System.Net.Http;

using Autofac;
using Autofac.Core;

using Calendar.Builder;

using Calendar.Web.Configuration;
using Calendar.Builder.ReleaseProviders;

namespace Calendar.Web.Dependencies.Configurators
{
    public class CalendarBuilderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReleaseEventCalendarBuilder>();

            builder.RegisterType<TvRageComReleaseProvider>()
                .As<ReleaseProviderBase>()
                .WithParameter("apiKey", ConfigurationProvider.Get<string>("ExternalServices:TvRange:apiKey"))
                .WithParameter("minDate", DateTime.Today.AddYears(-1));

            builder.Register(ctx => new HttpClient());

            builder.RegisterType<TvRageComSerialIdProvider>()       
                .Keyed<ISerialIdProvider>("serialIdProvider")
                .WithParameter("apiKey", ConfigurationProvider.Get<string>("ExternalServices:TvRange:apiKey"));

            builder.RegisterType<CachedSerialIdProvider>()
                .As<ISerialIdProvider>()
                .WithParameter(ResolvedParameter.ForNamed<ISerialIdProvider>("serialIdProvider"));
        }
    }
}