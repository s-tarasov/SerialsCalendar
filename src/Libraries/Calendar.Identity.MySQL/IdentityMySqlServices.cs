using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Identity.MySQL
{
    public class IdentityMySqlServices
    {
        public static IEnumerable<ServiceDescriptor> GetDefaultServices(Type userType, Type roleType)
        {
            var userStoreType = typeof(UserStore<,>).MakeGenericType(userType, roleType);
            var roleStoreType = typeof(RoleStore<>).MakeGenericType(roleType);

            yield return new ServiceDescriptor(typeof(IUserStore<>).MakeGenericType(userType), userStoreType, ServiceLifetime.Scoped);
            yield return new ServiceDescriptor(typeof(IRoleStore<>).MakeGenericType(roleType), roleStoreType, ServiceLifetime.Scoped);
        }
    }
}