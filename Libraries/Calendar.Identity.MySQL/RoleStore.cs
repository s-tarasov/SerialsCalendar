using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

namespace Calendar.Identity.MySQL
{
    public class RoleStore<TRole> :
       IQueryableRoleStore<TRole>,
       IRoleClaimStore<TRole>
       where TRole : IdentityRole
    {
        public IQueryable<TRole> Roles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}