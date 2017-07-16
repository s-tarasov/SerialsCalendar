using Autofac;

using Calendar.Caching;

namespace Calendar.Web.Dependencies.Configurators
{
    public class CachingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileSystemCache>()
                .As<IStringCache>()
                .WithParameter("directory", "Serialids");
        }
    }
}