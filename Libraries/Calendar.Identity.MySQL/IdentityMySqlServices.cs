using System;

using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;

namespace Calendar.Identity.MySQL
{
    public class IdentityMySqlServices
    {
        public static IServiceCollection GetDefaultServices(Type userType, Type roleType)
        {
            Type userStoreType = typeof(UserStore<,>).MakeGenericType(userType, roleType);
            Type roleStoreType = typeof(RoleStore<>).MakeGenericType(roleType);

            var services = new ServiceCollection();
            services.AddScoped(
                typeof(IUserStore<>).MakeGenericType(userType),
                userStoreType);
            services.AddScoped(
                typeof(IRoleStore<>).MakeGenericType(roleType),
                roleStoreType);
            return services;
        }
    }
}