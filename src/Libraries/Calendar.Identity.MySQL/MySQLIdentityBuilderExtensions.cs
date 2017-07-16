using Microsoft.AspNetCore.Identity;

using Calendar.Common.Extensions;

namespace Calendar.Identity.MySQL
{
    public static class MySQLIdentityBuilderExtensions
    {
        public static IdentityBuilder AddMySQLStores(this IdentityBuilder builder)
        {
            builder.Services.AddRange(IdentityMySqlServices.GetDefaultServices(builder.UserType, builder.RoleType));

            return builder;
        }
    }
}