using System;
using System.Net.Http;

using Autofac;
using Autofac.Core;

using SerialsCalendar;
using SerialsCalendar.ReleaseEventCalendar;

using Web.Configuration;

namespace Web.Dependencies
{
    public class CalendarModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReleaseEventCalendarBuilder>();

            builder.RegisterType<TvRageComReleaseEventsProvider>()
                .As<ReleaseEventsProviderBase>()
                .WithParameter("apiKey", ConfigurationProvider.Get<string>("tvrangekey"))
                .WithParameter("minDate", DateTime.Today.AddYears(-1));

            builder.Register(ctx => new HttpClient());

            builder.RegisterType<TvRageComSerialIdProvider>()       
                .Keyed<ISerialIdProvider>("serialIdProvider")
                .WithParameter("apiKey", ConfigurationProvider.Get<string>("tvrangekey"));

            builder.RegisterType<CachedSerialIdProvider>()
                .As<ISerialIdProvider>()
                .WithParameter(ResolvedParameter.ForNamed<ISerialIdProvider>("serialIdProvider"));

            builder.RegisterType<FileSystemCache>()
                .As<IStringCache>()
                .WithParameter("directory", "Serialids");
        }
    }
}