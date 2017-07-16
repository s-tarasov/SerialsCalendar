using System;
using System.Collections.Generic;

namespace Calendar.Identity.MySQL
{
    public class IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
        public IdentityRole() { }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="roleName"></param>
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }

        /// <summary>
        ///     Role id
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        ///     Role name
        /// </summary>
        public virtual string Name { get; set; }
        public virtual string NormalizedName { get; set; }

        /// <summary>
        /// A random value that should change whenever a role is persisted to the store
        /// </summary>
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}