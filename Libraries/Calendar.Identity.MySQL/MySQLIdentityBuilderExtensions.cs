using Microsoft.AspNet.Identity;

namespace Calendar.Identity.MySQL
{
    public static class MySQLIdentityBuilderExtensions
    {
        public static IdentityBuilder AddMySQLStores(this IdentityBuilder builder)
        {
            builder.Services.Add(IdentityMySqlServices.GetDefaultServices(builder.UserType, builder.RoleType));
            return builder;
        }
    }
}